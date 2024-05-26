-- Función para actualizar el stock en ingreso de mercancía
CREATE OR REPLACE FUNCTION update_stock_on_entry() RETURNS TRIGGER AS $$
BEGIN
    UPDATE Products
    SET Stock = Stock + NEW.Quantity,
        UpdatedAt = CURRENT_TIMESTAMP
    WHERE ProductID = NEW.ProductId;

    INSERT INTO StockHistories (ProductID, ChangeType, Quantity, ChangeDate, UserID)
    VALUES (NEW.ProductId, 'Entry', NEW.Quantity, CURRENT_TIMESTAMP, NEW.UserId);

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Trigger para actualizar el stock en ingreso de mercancía
CREATE TRIGGER trg_update_stock_on_entry
AFTER INSERT ON InventoryEntries
FOR EACH ROW
EXECUTE FUNCTION update_stock_on_entry();


-- Función para actualizar el stock en salida de mercancía
CREATE OR REPLACE FUNCTION update_stock_on_exit() RETURNS TRIGGER AS $$
BEGIN
    UPDATE Products
    SET Stock = Stock - NEW.Quantity,
        UpdatedAt = CURRENT_TIMESTAMP
    WHERE ProductID = NEW.ProductId;

    INSERT INTO StockHistories (ProductID, ChangeType, Quantity, ChangeDate, UserID)
    VALUES (NEW.ProductId, 'Exit', NEW.Quantity, CURRENT_TIMESTAMP, NEW.UserId);

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Trigger para actualizar el stock en salida de mercancía
CREATE TRIGGER trg_update_stock_on_exit
AFTER INSERT ON InventoryExits
FOR EACH ROW
EXECUTE FUNCTION update_stock_on_exit();
