-- Table: prompt_categories
-- This table stores the categories for prompt templates
CREATE TABLE IF NOT EXISTS prompt_categories (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    category_name VARCHAR(150) NOT NULL UNIQUE,
    description TEXT NULL,
    is_active TINYINT(1) DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Table: prompt_languages
-- This table stores the supported languages for prompts
CREATE TABLE IF NOT EXISTS prompt_languages (
    id INT AUTO_INCREMENT PRIMARY KEY,
    language_code VARCHAR(10) NOT NULL UNIQUE,
    language_name VARCHAR(100) NOT NULL UNIQUE,
    is_active TINYINT(1) DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Table: prompt_templates
-- This table stores prompt templates with references to categories and languages
CREATE TABLE IF NOT EXISTS prompt_templates (
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    prompt_categories_id BIGINT NOT NULL,
    language_id INT NOT NULL,
    system_prompt TEXT NOT NULL,
    user_prompt_template TEXT NOT NULL,
    temperature DECIMAL(3, 2) NOT NULL DEFAULT 0.70 CHECK (temperature >= 0 AND temperature <= 1),
    tags VARCHAR(255) NULL,
    is_active TINYINT(1) DEFAULT 1,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (prompt_categories_id) REFERENCES prompt_categories(id),
    FOREIGN KEY (language_id) REFERENCES prompt_languages(id),
    INDEX idx_category (prompt_categories_id),
    INDEX idx_title (title),
    INDEX idx_created_at (created_at)
);

-- Stored Procedure: sp_list_prompt_templates
-- This procedure lists prompt templates with pagination, search, and category filtering
DELIMITER //

DROP PROCEDURE IF EXISTS sp_list_prompt_templates//

CREATE PROCEDURE sp_list_prompt_templates(
    IN p_limit INT,
    IN p_offset INT,
    IN p_search VARCHAR(255),
    IN p_category VARCHAR(100)
)
BEGIN
    DECLARE v_search_pattern VARCHAR(257);
    
    -- Prepare search pattern
    IF p_search IS NOT NULL AND p_search != '' THEN
        SET v_search_pattern = CONCAT('%', p_search, '%');
    END IF;
    
    -- Get paginated templates with category and language information
    SELECT 
        pt.id,
        pt.title,
        pc.category_name AS category,
        pl.language_name AS language,
        pt.system_prompt,
        pt.user_prompt_template,
        pt.temperature,
        pt.tags,
        pt.is_active,
        pt.created_at,
        pt.updated_at
    FROM prompt_templates pt
    INNER JOIN prompt_categories pc ON pt.prompt_categories_id = pc.id
    INNER JOIN prompt_languages pl ON pt.language_id = pl.id
    WHERE 
        pt.is_active = 1
        AND (p_search IS NULL OR p_search = '' OR pt.title LIKE v_search_pattern OR pc.category_name LIKE v_search_pattern)
        AND (p_category IS NULL OR p_category = '' OR pc.category_name = p_category)
    ORDER BY pt.updated_at DESC
    LIMIT p_limit OFFSET p_offset;
    
    -- Get total count with same filters
    SELECT COUNT(*) as total
    FROM prompt_templates pt
    INNER JOIN prompt_categories pc ON pt.prompt_categories_id = pc.id
    WHERE 
        pt.is_active = 1
        AND (p_search IS NULL OR p_search = '' OR pt.title LIKE v_search_pattern OR pc.category_name LIKE v_search_pattern)
        AND (p_category IS NULL OR p_category = '' OR pc.category_name = p_category);
END//

DELIMITER ;
