
CREATE TABLE organisations (
    OrganisationId SERIAL PRIMARY KEY,
    `Name` VARCHAR(100) NOT NULL
);

CREATE TABLE products (
    ProductId SERIAL PRIMARY KEY,
    `Name` VARCHAR(100) NOT NULL
);

CREATE TABLE users (
    UserId SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE customers (
    CustomerId SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE orders (
    OrderId SERIAL PRIMARY KEY
);

-- Insert a few records into the users table
INSERT INTO users (name, email) VALUES ('John Doe', 'john.doe@example.com');
INSERT INTO users (name, email) VALUES ('Jane Smith', 'jane.smith@example.com');
INSERT INTO users (name, email) VALUES ('Samuel Jackson', 'samuel.jackson@example.com');