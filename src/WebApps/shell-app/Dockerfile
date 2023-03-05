FROM node:14-alpine AS build
WORKDIR /app
COPY ["WebApps/shell-app/package.json", "WebApps/shell-app/package-lock.json", "./"]
RUN npm install
COPY ["WebApps/shell-app/.", "./"]
RUN ["npm", "run", "build"]

FROM nginx:latest
COPY ["WebApps/shell-app/nginx.conf", "/etc/nginx/nginx.conf"]
COPY ["WebApps/shell-app/src/assets/config.json", "/user/share/nginx/html/assets/config.json"]
COPY --from=build /app/dist/shell-app /usr/share/nginx/html
EXPOSE 80
