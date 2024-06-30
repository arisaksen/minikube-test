# Startup localhost

## Minikube

```bash
minikube docker-env
eval $(minikube -p minikube docker-env)

# to set back to normal localhost
docker context ls
unset DOCKER_HOST
docker context use colima
```

`docker images`
command will now list the images inside minikube

### Deploy/Redeploy change. + with no-cache

```bash
docker build -t api1-image api1/.;kubectl delete -f api1-k8s.yaml;kubectl apply -f api1-k8s.yaml

# use no-cache if trouble with docker images not updated
docker build --no-cache -t api1-image api1/.;kubectl delete -f api1-k8s.yaml;kubectl apply -f api1-k8s.yaml
docker build --no-cache -t api2-image api2/api2/.;kubectl delete -f api2-k8s.yaml;kubectl apply -f api2-k8s.yaml
```

Mysql before api2

```bash
kubectl apply -f mysql-k8s.yaml

docker build -t api2-image api2/.;kubectl delete -f api2-k8s.yaml;kubectl apply -f api2-k8s.yaml
```

### Access deployed service

```bash

minikube service api1-svc
minikube service api2-svc
```

Then add url in browser or postman: http://127.0.0.1:56962/api/book
(change port)

### Docker remove old images

```bash
docker image prune -a -f
```

### Mount folder from localhost into minikube

```bash
minikube mount ~/workspace/learning/kubernetes/minikube-test:/tmp/data
```

This can than be mounted again into the container like this

```yaml
          containers:
            - name: api1
              image: api1-image
              imagePullPolicy: Never
              ports:
                - containerPort: 8080
              volumeMounts:
                - mountPath: /tmp/data
                  name: api1-volume
          volumes:
            - name: api1-volume
              hostPath:
                # directory location on minikube host
                path: /tmp/data
```

### Troubleshoot pods

```bash
kubectl logs <pod-name>
```
