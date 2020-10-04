#accelerate:[-1,1],direction:[-1,1]
# enviar a rafa: speed[-50,150], sensorIzq[0,metros],sensorCentro[0,metros], sensorIzq[0,metros]
import socket



def inputDataToDict(unityInput):

    speed = extractValue(unityInput,'speed:')
    rightDistance = extractValue(unityInput,'rightDistance:')
    leftDistance = extractValue(unityInput,'leftDistance:')
    frontDistance = extractValue(unityInput,'frontDistance:')



    carInfo = {}

    carInfo['speed'] = speed
    carInfo['leftDistance'] = leftDistance
    carInfo['frontDistance'] = frontDistance
    carInfo['rightDistance'] = rightDistance
    return carInfo

def findEnd(mainString, subString):
    return int(mainString.find(subString) + len(subString))

def extractValue(mainString, subString):
    return float(mainString[findEnd(mainString, subString): findEnd(mainString, subString)+2])


host, port = "127.0.0.1",25001
data = "accelerate:1,direction:1" 

sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))

'''
i = 0
go = True
while go:
    i+=1
    try:
        sock.sendall(data.encode("utf-8"))
        print('Data sent is' + data)
        inputData = sock.recv(1024).decode("utf-8")
        print('Data received' + inputData)

    finally: 
        if (i == 8000):
            data ="accelerate:3,direction:0"
            if (i == 20000):
                data ="accelerate:1,direction:-1"
                if (i == 40000):
                    data ="accelerate:0,direction:0"
                    if(i == 90000):
                        go = False

sock.close()

'''

i = 0
go = True
data = "accelerate:0.2,direction:0"
while go:
    i+=1
    try:
        sock.sendall(data.encode("utf-8"))
        print('Data sent is' + data)
        inputData = sock.recv(1024).decode("utf-8")
        print(inputData)
        print(inputDataToDict(inputData))

    finally:
        if(i > 9000):
            go = False

sock.close()
