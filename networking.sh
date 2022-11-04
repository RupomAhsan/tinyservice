#!/bin/bash
iptables -t nat -A PREROUTING -p tcp -i eth0 --dport 3000 -j REDIRECT --to-port 3050
iptables -t nat --list