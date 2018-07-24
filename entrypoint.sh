set -e
run_cmd="dotnet Labange.PL.dll --server.urls http://*:80"

exec dotnet ef database update

>&2 echo "SQL Server is up - executing command"
exec $run_cmd