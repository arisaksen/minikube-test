# Startup localhost

## Minikube

```bash
minikube docker-env
eval $(minikube -p minikube docker-env)
```

`docker images`
command will now list the images inside minikube

## Docker

### Build images apis

```bash
cd /api1/api1
docker build -t api1-image .
```

```bash
cd /api2/api2
docker build -t api2-image .
```

### List images

```bash
$ docker images 
REPOSITORY                          TAG           IMAGE ID       CREATED          SIZE
api1-image                          latest        fa066de73957   28 seconds ago   8.72MB
api2-image                          latest        36dffb51dc91   8 minutes ago    268MB
```

### Deploy to minikube

```bash
kubectl apply -f api1-k8s.yaml
kubectl get deployments

minikube service api1-svc
```

### Redeploy change - all in one

```bash
docker build --no-cache -t api1-image api1/.;kubectl delete -f api1-k8s.yaml;kubectl apply -f api1-k8s.yaml
```

### Docker remove old images

```bash
docker image prune -a -f
```