# Prompt Templates Database Schema

## Overview
This schema provides a complete database structure for managing prompt templates with support for categories and multiple languages.

## Tables

### 1. `prompt_categories`
Stores categories for organizing prompt templates.

**Columns:**
- `id` - Primary key (BIGINT)
- `category_name` - Unique category name (VARCHAR 150)
- `description` - Optional category description (TEXT)
- `is_active` - Active status flag (TINYINT 0/1)
- `created_at` - Timestamp of creation
- `updated_at` - Timestamp of last update

### 2. `prompt_languages`
Stores supported languages for prompts.

**Columns:**
- `id` - Primary key (INT)
- `language_code` - Unique language code (VARCHAR 10, e.g., 'en', 'es', 'fr')
- `language_name` - Unique language name (VARCHAR 100)
- `is_active` - Active status flag (TINYINT 0/1)
- `created_at` - Timestamp of creation
- `updated_at` - Timestamp of last update

### 3. `prompt_templates`
Main table storing prompt templates with relationships to categories and languages.

**Columns:**
- `id` - Primary key (BIGINT)
- `title` - Template title (VARCHAR 255)
- `prompt_categories_id` - Foreign key to prompt_categories (BIGINT)
- `language_id` - Foreign key to prompt_languages (INT)
- `system_prompt` - System-level prompt text (TEXT)
- `user_prompt_template` - User prompt template (TEXT)
- `temperature` - AI temperature parameter (DECIMAL 0.00-1.00, default 0.70)
- `tags` - Optional comma-separated tags (VARCHAR 255)
- `is_active` - Active status flag (TINYINT 0/1)
- `created_at` - Timestamp of creation
- `updated_at` - Timestamp of last update

**Indexes:**
- `idx_category` - On prompt_categories_id
- `idx_title` - On title
- `idx_created_at` - On created_at

## Stored Procedure

### `sp_list_prompt_templates`

Lists prompt templates with pagination, search functionality, and category filtering.

**Parameters:**
- `p_limit` (INT) - Maximum number of records to return
- `p_offset` (INT) - Number of records to skip (for pagination)
- `p_search` (VARCHAR 255) - Optional search term (searches in title and category name)
- `p_category` (VARCHAR 100) - Optional category name filter

**Returns:**
Two result sets:
1. **Paginated Records:**
   - id
   - title
   - category (joined from prompt_categories)
   - language (joined from prompt_languages)
   - system_prompt
   - user_prompt_template
   - temperature
   - tags
   - is_active
   - created_at
   - updated_at

2. **Total Count:**
   - total (number of records matching the filters)

**Features:**
- Only returns active templates (`is_active = 1`)
- Supports wildcard search in title and category name
- Filters by exact category name match
- Orders results by updated_at DESC (most recently updated first)
- Uses INNER JOINs to ensure referential integrity

**Usage Examples:**

```sql
-- Get first 10 templates (page 1)
CALL sp_list_prompt_templates(10, 0, NULL, NULL);

-- Get next 10 templates (page 2)
CALL sp_list_prompt_templates(10, 10, NULL, NULL);

-- Search for templates containing "email"
CALL sp_list_prompt_templates(20, 0, 'email', NULL);

-- Get templates in "Marketing" category
CALL sp_list_prompt_templates(50, 0, NULL, 'Marketing');

-- Search for "report" in "Analytics" category
CALL sp_list_prompt_templates(10, 0, 'report', 'Analytics');
```

## Setup Instructions

1. Run the SQL file to create tables and stored procedure:
```bash
mysql -u your_username -p your_database < SQL/prompt_templates_schema.sql
```

2. Insert sample categories:
```sql
INSERT INTO prompt_categories (category_name, description) VALUES
('Marketing', 'Marketing and advertising prompts'),
('Analytics', 'Data analysis and reporting prompts'),
('Support', 'Customer support and service prompts');
```

3. Insert sample languages:
```sql
INSERT INTO prompt_languages (language_code, language_name) VALUES
('en', 'English'),
('es', 'Spanish'),
('fr', 'French');
```

4. Insert sample templates:
```sql
INSERT INTO prompt_templates 
(title, prompt_categories_id, language_id, system_prompt, user_prompt_template, temperature, tags) 
VALUES
('Email Campaign', 1, 1, 'You are a marketing expert.', 'Create an email campaign for {product}', 0.70, 'email,marketing'),
('Sales Report', 2, 1, 'You are a data analyst.', 'Generate a sales report for {period}', 0.50, 'report,analytics');
```

## Migration from Old Schema

If you're migrating from the old schema where `category` was a direct column:

1. **Backup your data**
2. **Create the new tables** (prompt_categories, prompt_languages)
3. **Migrate categories:**
```sql
INSERT INTO prompt_categories (category_name)
SELECT DISTINCT category FROM old_prompt_templates WHERE category IS NOT NULL;
```

4. **Update prompt_templates** to use foreign keys instead of direct category text
5. **Drop the old stored procedure** and create the new one

## Notes

- The stored procedure only returns active templates by default
- Search is case-insensitive (using LIKE operator)
- Empty string parameters are treated the same as NULL
- The procedure returns two result sets - handle appropriately in your application
