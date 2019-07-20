FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet GainzWebAPI.dll -c DATABASE_URL=$DATABASE_URL MAILCHIMP_AUTH=$MAILCHIMP_AUTH