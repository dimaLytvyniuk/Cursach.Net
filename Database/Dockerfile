FROM microsoft/mssql-server-linux
COPY sqlmigration.sql /data
RUN sqlcmd /data/sqlmigration.sql