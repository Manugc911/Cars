#accelerate:[-1,1],direction:[-1,1]
# enviar a rafa: speed[-50,150], sensorIzq[0,metros],sensorCentro[0,metros], sensorIzq[0,metros]
import socket
host, port = "127.0.0.1",25001
data = "accelerate:1,direction:1" 

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))
i = 0
go = True
while go:
    i+=1
    try:
        sock.sendall(data.encode("utf-8"))
        data = sock.recv(1024).decode("utf-8")
        print(data)
        
    finally: 
        if (i > 8000):
            data ="accelerate:3,direction:0"
            if (i > 20000):
                data ="accelerate:1,direction:-1"
                if (i > 40000):
                    data ="accelerate:0,direction:0"
                    if(i>90000):
                        go = False

sock.close()