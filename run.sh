docker-compose up --build

while ! curl --fail --silent --head http://localhost:8080; do
  sleep 1
done

open http://localhost:8000