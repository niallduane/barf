dotnet clean;

find ./examples/example1 -type f -not -name 'sql-server-solution.sh'  -delete

find ./examples/example2 -type f -not -name 'mysql-solution.sh' -delete

find ./examples/example3 -type f -not -name 'postgres-solution.sh' -delete
