IF NOT EXISTS (
    SELECT
        name
    FROM
        sys.databases
    WHERE
        name = 'barfsourcenamedb'
) BEGIN CREATE DATABASE barfsourcenamedb;

END;