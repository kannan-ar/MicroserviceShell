FROM node:14-alpine AS build
WORKDIR /app
COPY ["WebApps/shell-app-identity/package.json", "WebApps/shell-app-identity/package-lock.json", "./"]
RUN npm install
COPY ["WebApps/shell-app-identity/.", "./"]
RUN ["npm", "run", "build"]

FROM nginx:latest
COPY ["WebApps/shell-app-identity/nginx.conf", "/etc/nginx/nginx.conf"]
COPY --from=build /app/dist/shell-app-identity /usr/share/nginx/html
EXPOSE 80