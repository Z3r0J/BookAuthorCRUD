#Stage 1

# Use official node image as the base image

FROM node:19-alpine as build

# Set the working directory

WORKDIR /usr/local/app

# Add the source code to app

COPY . /usr/local/app

# Install all the dependencies

RUN npm install

# Generate the build of the application

RUN npm run build

# Stage 2

# Use official nginx image as the base image

FROM nginx:latest

# Copy the build output to replace the default nginx contents.

COPY --from=build /usr/local/app/dist/frontend /usr/share/nginx/html

# Expose port 80

EXPOSE 80

# Start nginx server

CMD ["nginx", "-g", "daemon off;"]

