## Techniques for working with ConfigMaps

1. Using a k8s ConfigMap manifest:  `kubectl create -f settings.configmap.yml`
2. Load settings from a file: `kubectl create cm app-settings --from-file=settings.properties`. Will add file name as key into ConfigMap data. Will NOT add quotes around non-string values.
3. Load settings from an env file: `kubectl create cm app-settings --from-env-file=settings.config`. Will NOT add file name as key into ConfigMap data. Will add quotes around non-string values.
4. Define settings in kubectl command: `kubectl create cm app-settings --from-literal=apiUurl=https://my-api  --from-literal=otherKey=otherValue --from-literal=count=50`. Will add quotes around non-string values.

## To Run Node Server and Access ConfigMap Data

Demo of accessing ConfigMap data in a Pod container through environment variables and direct settings.

1. Delete any ConfigMaps you added into k8s above via:

`kubectl delete cm app-settings`

2. Build the TinyService Project

`dotnet run --project src/TinyService`

3. Build image: `docker build -t tinyservice .`

4. Create ConfigMap:

`kubectl create cm app-settings --from-env-file=settings.config`

5. Get ConfigMaps dretails with yaml file
`kubectl get cm app-settings -o yaml`

6. Create deployment: 

`kubectl apply -f configMaps.deployment.yml`

7. Port forward the Pod: 

`kubectl port-forward [pod-name] 3000`

8. Visit `http://localhost:3000/getConfigMap` and view the ConfigMap settings output






