
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy everything else and build app
COPY Labange.BLL/. ./Labange.BLL/
COPY Labange.DAL/. ./Labange.DAL/
COPY Labange.PL/.  ./Labange.PL/
WORKDIR /app/Labange.PL
RUN dotnet publish -c Release -o /app/output
WORKDIR /app
COPY entrypoint.sh /app/output

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/output ./
EXPOSE 80/tcp
RUN ls
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
#ENTRYPOINT ["dotnet", "Labange.PL.dll"]
