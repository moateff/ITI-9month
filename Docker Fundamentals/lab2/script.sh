# task1
# run a container nginx with name my-nginx and attach volume to the 
# container using volume mount 

# create a volume for containing static html file 
docker volume create html-data

docker run -d \
  --name my-nginx \
  -v html-data:/usr/share/nginx/html \
  nginx

# edit the html content 
docker exec -it my-nginx bash
echo "<h1>Hello from Docker Volume</h1>" > /usr/share/nginx/html/index.html
exit

# remove the container 
docker rm -f my-nginx

# run a new container with the following: 
# attach the volume that were attached to the previous container using volume mount 
# map port 80 to port 8080 on you host machine 
# access the html files from your browser
docker run -d \
  --name my-nginx-v2 \
  -p 8080:80 \
  -v html-data:/usr/share/nginx/html \
  nginx


# task2
# create a Dockerfile 
# use an official Python image 
# copy the Python script into the image
# run the script when the container starts 
docker build -t my-python-app .

docker run --name python-container my-python-app


# task3
# create docker compose with: 
# two services nginx and mysql 
# add needed ports and environments for both services 
# nginx service is depending on mysql
docker compose up -d
docker compose ps

docker compose down