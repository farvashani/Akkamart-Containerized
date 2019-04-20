# cd Akkamart/Seed1 ; sh build_docker.sh
# cd Akkamart/Credentials ; sh build_docker.sh
# cd Akkamart/Gateway ; sh build_docker.sh
# cd Akkamart/Memberships ; sh build_docker.sh
# cd Akkamart/Messangers ; sh build_docker.sh
# cd Akkamart/Gateway ; sh build_docker.sh
pwd
cd Akkamart/Seed1
sh build_docker.sh
pwd
cd ..
cd Credentials
sh build_docker.sh
pwd
cd ..
cd Gateway 
pwd
cd ../Memberships 
sh build_docker.sh
pwd
cd ../Messangers 
sh build_docker.sh
pwd
cd ../Gateway 
sh build_docker.sh
pwd