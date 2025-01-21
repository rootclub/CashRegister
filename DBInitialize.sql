-- DB Prodotti
-- Compatibile con SQLite e PostgreSQL

-- Tabella per le categorie dei prodotti nel menu
CREATE TABLE categories (
    id SERIAL PRIMARY KEY,              -- Chiave primaria auto-incrementale
    name VARCHAR(400) NOT NULL,         -- Nome della categoria
    description TEXT,                   -- Descrizione della categoria (opzionale)
    sort_order INT                      -- Ordine di visualizzazione della categoria (opzionale)
);

-- Tabella per i prodotti generici
CREATE TABLE products (
    barcode VARCHAR(100) PRIMARY KEY,   -- Codice a barre (chiave primaria)
    name VARCHAR(400) NOT NULL,         -- Nome del prodotto
    image TEXT,                         -- Percorso o URL dell'immagine (opzionale)
    description TEXT,                   -- Descrizione del prodotto (opzionale)
    weight_volume DECIMAL(10, 2),       -- Peso/volume del prodotto
    weight_volume_unit VARCHAR(10),     -- Unità di misura del peso/volume
    price DECIMAL(10, 2) NOT NULL,      -- Costo del prodotto
    vat_type DECIMAL(5, 2),             -- Tipo di aliquota IVA (valori possibili: 4, 5, 10, 22)
    -- Valori nutrizionali (tutti opzionali)
    energy DECIMAL(20, 10),             -- In kcal
    total_fat DECIMAL(20, 10),          -- In g
    saturated_fat DECIMAL(20, 10),      -- In g
    trans_fat DECIMAL(20, 10),          -- In g
    polyunsaturated_fat DECIMAL(20, 10),-- In g
    monounsaturated_fat DECIMAL(20, 10),-- In g
    cholesterol DECIMAL(20, 10),        -- In mg
    sodium DECIMAL(20, 10),             -- In mg
    total_carbs DECIMAL(20, 10),        -- In g
    dietary_fiber DECIMAL(20, 10),      -- In g
    soluble_fiber DECIMAL(20, 10),      -- In g
    total_sugars DECIMAL(20, 10),       -- In g
    added_sugars DECIMAL(20, 10),       -- In g
    vitamin_d DECIMAL(20, 10),          -- in mcg
    calcium DECIMAL(20, 10),            -- In mg
    iron DECIMAL(20, 10),               -- In mg
    potassium DECIMAL(20, 10),          -- In mg
    vitamin_a DECIMAL(20, 10),          -- In mcg
    vitamin_c DECIMAL(20, 10),          -- In mg
    thiamin DECIMAL(20, 10),            -- In mg
    riboflavin DECIMAL(20, 10),         -- In mg
    niacin DECIMAL(20, 10),             -- In mg
    vitamin_b6 DECIMAL(20, 10),         -- In mg
    folate DECIMAL(20, 10),             -- In mcg
    vitamin_b12 DECIMAL(20, 10),        -- In mcg
    phosphorus DECIMAL(20, 10),         -- In mg
    magnesium DECIMAL(20, 10),          -- In mg
    zinc DECIMAL(20, 10),               -- In mg
    ethanol DECIMAL(5, 2),              -- In % su volume/peso
    -- Allergeni (0 = NON CONTIENE, 1 = PUÒ CONTENERE TRACCE, 2 = CONTIENE)
    gluten SMALLINT DEFAULT 0,
    crustaceans SMALLINT DEFAULT 0,
    eggs SMALLINT DEFAULT 0,
    fish SMALLINT DEFAULT 0,
    peanuts SMALLINT DEFAULT 0,
    soy SMALLINT DEFAULT 0,
    milk SMALLINT DEFAULT 0,
    nuts SMALLINT DEFAULT 0,
    celery SMALLINT DEFAULT 0,
    sesame SMALLINT DEFAULT 0,
    sulfur_dioxide SMALLINT DEFAULT 0,
    lupin SMALLINT DEFAULT 0,
    mollusks SMALLINT DEFAULT 0,
    mustard SMALLINT DEFAULT 0,
    other_allergens TEXT                -- Altri allergeni non elencati (opzionale)
);

-- Tabella per i prodotti nel menu
CREATE TABLE menu_products (
    barcode VARCHAR(100) PRIMARY KEY,   -- Codice a barre del prodotto (PK e FK verso products)
    category_id INT NOT NULL,           -- ID della categoria di appartenenza (FK verso categories)
    alt_title VARCHAR(400),             -- Titolo alternativo (opzionale)
    alt_description TEXT,               -- Descrizione alternativa (opzionale)
    embedding JSONB,                    -- Dati di embedding (opzionale, in formato JSON)
    recommended BOOLEAN DEFAULT FALSE,  -- Indica se il prodotto è consigliato
    FOREIGN KEY (barcode) REFERENCES products(barcode),  -- Relazione con la tabella products
    FOREIGN KEY (category_id) REFERENCES categories(id)  -- Relazione con la tabella categories
);

-- Tabella per i tag
CREATE TABLE tags (
    id SERIAL PRIMARY KEY,              -- Chiave primaria auto-incrementale
    name VARCHAR(255) NOT NULL          -- Nome del tag
);

-- Tabella di collegamento molti-a-molti tra prodotti e tag
CREATE TABLE product_tags (
    tag_id INT,                         -- ID del tag (chiave esterna verso tags)
    product_barcode VARCHAR(100),       -- Codice a barre del prodotto (chiave esterna verso products)
    PRIMARY KEY (tag_id, product_barcode),  -- Chiave primaria composta
    FOREIGN KEY (tag_id) REFERENCES tags(id),                   -- Relazione con tags
    FOREIGN KEY (product_barcode) REFERENCES products(barcode)  -- Relazione con products
);

-- Tabella per i menu del giorno
CREATE TABLE daily_menus (
    id SERIAL PRIMARY KEY,              -- Chiave primaria auto-incrementale
    title VARCHAR(400) NOT NULL,        -- Titolo del menu
    description TEXT,                   -- Descrizione del menu (opzionale)
    cost DECIMAL(10, 2) NOT NULL        -- Costo del menu
);

CREATE TABLE inv_transactions (
    transaction_id SERIAL PRIMARY KEY,  -- ID univoco della transazione (autoincrementale)
    transaction_timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- Timestamp della transazione
    barcode VARCHAR(100) NOT NULL,      -- Codice a barre del prodotto (chiave esterna verso products)
    transaction_type VARCHAR(20) NOT NULL,  -- Tipo di transazione: 'RIFORNIMENTO', 'INVENTARIO', 'VENDITA'
    quantity INT NOT NULL,              -- Quantità modificata (positiva o negativa)
    current_quantity INT NOT NULL,      -- Quantità corrente (post transazione)
    unit_price DECIMAL(10, 2),          -- Prezzo unitario:
                                        -- - Prezzo di acquisto per 'RIFORNIMENTO'
                                        -- - Prezzo di vendita per 'VENDITA'
                                        -- - NULL per 'INVENTARIO' (non applicabile)
    FOREIGN KEY (barcode) REFERENCES products(barcode)  -- Relazione con la tabella products
);
