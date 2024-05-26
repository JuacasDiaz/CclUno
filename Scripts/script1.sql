-- Tabla Users
CREATE TABLE Users (
    UserID SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla Products
CREATE TABLE Products (
    ProductID SERIAL PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2),
    Stock INT DEFAULT 0,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla InventoryEntries
CREATE TABLE InventoryEntries (
    EntryID SERIAL PRIMARY KEY,
    ProductID INT NOT NULL REFERENCES Products(ProductID),
    UserID INT NOT NULL REFERENCES Users(UserID),
    Quantity INT NOT NULL,
    EntryType VARCHAR(50) NOT NULL, -- 'Purchase', 'Transfer'
    EntryDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla InventoryExits
CREATE TABLE InventoryExits (
    ExitID SERIAL PRIMARY KEY,
    ProductID INT NOT NULL REFERENCES Products(ProductID),
    UserID INT NOT NULL REFERENCES Users(UserID),
    Quantity INT NOT NULL,
    ExitType VARCHAR(50) NOT NULL, -- 'Sale', 'Damage', 'Transfer'
    ExitDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla Stocks
CREATE TABLE Stocks (
    StockID SERIAL PRIMARY KEY,
    ProductID INT NOT NULL UNIQUE REFERENCES Products(ProductID),
    Quantity INT NOT NULL
);

-- Tabla StockHistories
CREATE TABLE StockHistories (
    HistoryID SERIAL PRIMARY KEY,
    ProductID INT NOT NULL REFERENCES Products(ProductID),
    UserID INT NOT NULL REFERENCES Users(UserID),
    ChangeType VARCHAR(50) NOT NULL, -- 'Entry', 'Exit'
    Quantity INT NOT NULL,
    ChangeDate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
