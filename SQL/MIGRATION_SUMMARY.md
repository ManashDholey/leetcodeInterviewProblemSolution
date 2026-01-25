# sp_list_prompt_templates - Migration Summary

## Overview
This document explains the changes made to the `sp_list_prompt_templates` stored procedure to accommodate the new normalized database schema.

## Schema Changes

### Old Schema (Before)
```sql
CREATE TABLE prompt_templates (
    id BIGINT,
    title VARCHAR(255),
    category VARCHAR(100),        -- Direct text field
    system_prompt TEXT,
    user_prompt_template TEXT,
    temperature DECIMAL(3, 2),
    created_at TIMESTAMP,
    updated_at TIMESTAMP
);
```

### New Schema (After)
```sql
CREATE TABLE prompt_categories (
    id BIGINT PRIMARY KEY,
    category_name VARCHAR(150) UNIQUE,
    ...
);

CREATE TABLE prompt_languages (
    id INT PRIMARY KEY,
    language_code VARCHAR(10) UNIQUE,
    language_name VARCHAR(100) UNIQUE,
    ...
);

CREATE TABLE prompt_templates (
    id BIGINT PRIMARY KEY,
    title VARCHAR(255),
    prompt_categories_id BIGINT,    -- Foreign key
    language_id INT,                -- Foreign key (new)
    system_prompt TEXT,
    user_prompt_template TEXT,
    temperature DECIMAL(3, 2),
    tags VARCHAR(255),              -- New field
    is_active TINYINT(1),           -- New field
    created_at TIMESTAMP,
    updated_at TIMESTAMP,
    FOREIGN KEY (prompt_categories_id) REFERENCES prompt_categories(id),
    FOREIGN KEY (language_id) REFERENCES prompt_languages(id)
);
```

## Stored Procedure Changes

### Old Implementation
```sql
CREATE PROCEDURE sp_list_prompt_templates(...)
BEGIN
    SELECT 
        id,
        title,
        category,                    -- Direct column
        system_prompt,
        user_prompt_template,
        temperature,
        created_at,
        updated_at
    FROM prompt_templates
    WHERE 
        (p_search IS NULL OR title LIKE v_search_pattern OR category LIKE v_search_pattern)
        AND (p_category IS NULL OR category = p_category)   -- Direct comparison
    ORDER BY updated_at DESC
    LIMIT p_limit OFFSET p_offset;
    
    SELECT COUNT(*) as total
    FROM prompt_templates
    WHERE 
        (p_search IS NULL OR title LIKE v_search_pattern OR category LIKE v_search_pattern)
        AND (p_category IS NULL OR category = p_category);
END
```

### New Implementation
```sql
CREATE PROCEDURE sp_list_prompt_templates(...)
BEGIN
    SELECT 
        pt.id,
        pt.title,
        pc.category_name AS category,        -- JOIN from categories table
        pl.language_name AS language,        -- JOIN from languages table (new)
        pt.system_prompt,
        pt.user_prompt_template,
        pt.temperature,
        pt.tags,                             -- New field
        pt.is_active,                        -- New field
        pt.created_at,
        pt.updated_at
    FROM prompt_templates pt
    INNER JOIN prompt_categories pc ON pt.prompt_categories_id = pc.id
    INNER JOIN prompt_languages pl ON pt.language_id = pl.id
    WHERE 
        pt.is_active = 1                     -- New filter
        AND (p_search IS NULL OR p_search = '' OR pt.title LIKE v_search_pattern OR pc.category_name LIKE v_search_pattern)
        AND (p_category IS NULL OR p_category = '' OR pc.category_name = p_category)
    ORDER BY pt.updated_at DESC
    LIMIT p_limit OFFSET p_offset;
    
    SELECT COUNT(*) as total
    FROM prompt_templates pt
    INNER JOIN prompt_categories pc ON pt.prompt_categories_id = pc.id
    INNER JOIN prompt_languages pl ON pt.language_id = pl.id    -- Consistent with main query
    WHERE 
        pt.is_active = 1
        AND (p_search IS NULL OR p_search = '' OR pt.title LIKE v_search_pattern OR pc.category_name LIKE v_search_pattern)
        AND (p_category IS NULL OR p_category = '' OR pc.category_name = p_category);
END
```

## Key Improvements

1. **Normalized Data Structure**: Categories and languages are now managed in separate tables, reducing data redundancy and improving data integrity.

2. **INNER JOINs**: The procedure now uses INNER JOINs to retrieve related data:
   - `prompt_categories` to get category names
   - `prompt_languages` to get language information

3. **Enhanced Filtering**: 
   - Only returns active templates (`is_active = 1`)
   - Handles empty strings in addition to NULL values

4. **Additional Data**: Returns more information:
   - `language` - The language name from the languages table
   - `tags` - Template tags
   - `is_active` - Active status

5. **Consistency**: Both the main query and count query use identical JOINs and WHERE clauses, ensuring accurate pagination.

6. **Data Integrity**: INNER JOINs ensure that only templates with valid category and language references are returned.

## Benefits of the New Approach

- **Better Data Management**: Categories can be managed independently
- **Referential Integrity**: Foreign key constraints prevent orphaned records
- **Extensibility**: Easy to add new languages or categories without modifying templates
- **Performance**: Indexed foreign keys improve query performance
- **Consistency**: Standardized category names (no duplicates due to typos)

## API Compatibility

The stored procedure maintains the same interface:
- Same parameters: `p_limit`, `p_offset`, `p_search`, `p_category`
- Same result structure with `category` column (aliased from `category_name`)
- Additional columns in response: `language`, `tags`, `is_active`

Applications calling this procedure will continue to work with minimal changes, only needing to handle the new fields if desired.
