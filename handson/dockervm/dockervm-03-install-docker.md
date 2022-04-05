# Linux VMでの、Docker Engineのセットアップ

[Docker公式の手順](https://docs.docker.com/engine/install/ubuntu/)に添って、Docker Engineをセットアップする。

さきほど開いたターミナルで以下を投入する。

```sh
sudo apt-get remove docker docker-engine docker.io containerd runc
sudo apt-get update
sudo apt-get install -y ca-certificates curl gnupg lsb-release
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg
echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu \
  $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
sudo apt-get update
sudo apt-get install -y docker-ce docker-ce-cli containerd.io
```

さらに、[Dockerを一般ユーザーで実行できるようにする。](https://docs.docker.com/engine/install/linux-postinstall/#manage-docker-as-a-non-root-user)

```
sudo groupadd docker
sudo usermod -aG docker $USER
newgrp docker
```
