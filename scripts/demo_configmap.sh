# Create a ConfigMap using data from a config file
kubectl create configmap [cm-name] --from-file=[path-to-file]

# Create a ConfigMap from an env file
kubectl create configmap [cm-name] --from-env-file=[path-to-file]

# Create a ConfigMap from individual da values
kubectl create configmap [cm-name] 
    --from-literal=apiUrl=https://my-api
    --from-literal=otherKey=otherValue
    
# Create from a Config manifest
kubectl create -f file.configmap.yml --save-config


# * Create a secret and store securely in kubernetes
kubectl create secret generic my-secret 
    --from-literal=pwd=my-password

# * Create a secret from a file
kubectl create secret generic my-secret
    --from-file=ssh-privatekey=~/.ssh/id_rsa
    --from-file=ssh-publickey=~/.ssh/id_rsa.pub

# * Create a secret from a key pair
kubectl create secret tls-secret --cert=path/to/tls.create
    --key=path/to/tls.key