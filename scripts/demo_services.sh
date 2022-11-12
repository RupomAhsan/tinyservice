# Port Forwarding

## Q: How can you access a Pod from outside of Kubernetes?
## A: Port forwarding

# Use the kubectl port-forward to forward a local port to a Pod port

# Listen on port 88 locally and forward to port 80 in Pod
kubectl port-forward pod/[pod-name] 88:80

# Listen on port 88 locally and forward to Deployment's Pod
kubectl port-forward deployment/[deployment-name] 88

# Listen on port 88 locally and forward to Service's Pod
kubectl port-forward service/[service-name] 88



# Create a Deployment    
kubectl create -f deployment.yml
        ## Use the kubectl create command along with --filename or -f switch
        ## Use --save-config when you want to use
kubectl create -f deployment.yml --save-config # Store current properties in resource's annotations

# Alternate way to create or app changes to a Deployment from YAML
kubectl apply -f deployment.yml
    ## kubectl apply in the future

# List all deployments and their labels
kubectl get deployment --show-labels

# Get all Deployments with a specific label
kubectl get deployment -l app=my-tinyservice

# Delete Deployment
kubectl delete deployment [deployment-name]

# Scale the Deployment Pods to 5
kubectl scal deployment [deployment-name] --replicas=5

# scale by refering the YAML file
kubectl scale -f deployment.yml --replicas=5





