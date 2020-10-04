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


str = 'rightDistance:99,leftDistance:8.59,frontDistance:99,speed: 0.11accelerate:0.2,direction:0accelerate:0.2,direction:0'
# str = 'rightDistance:99,leftDistance:8.59,frontDistance:99,speed: 0.11accelerate:0.2,direction:0accelerate:0.2,direction:0'
print(inputDataToDict(str))
