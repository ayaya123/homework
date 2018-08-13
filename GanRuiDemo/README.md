# 贪吃蛇
## **功能描述**
由Python 3.6编写的贪吃蛇小游戏，通过方向键或WSAD键控制贪吃蛇的上下左右移动。

## **开发环境**
### **Python 3.6**
pygame 1.9.4

sys

random

time

## **安装流程**
安装Anaconda3时自动安装Python3.6，其中sys、random、time库集成在内。
pip install安装pygame库。

## **代码简述**
定义颜色变量
``` 
redColour = pygame.Color(255,0,0)
blackColour = pygame.Color(0,0,0)
whiteColour = pygame.Color(255,255,255)
greyColour = pygame.Color(150,150,150)
```
定义gameover函数，控制游戏结束
```
def gameOver(playSurface):
    gameOverFont = pygame.font.Font('arial.ttf',72)
    gameOverSurf = gameOverFont.render('Game Over', True, greyColour)
    gameOverRect = gameOverSurf.get_rect()
    gameOverRect.midtop = (320, 10)
    playSurface.blit(gameOverSurf, gameOverRect)
    pygame.display.flip()
    time.sleep(5)
    pygame.quit()
    sys.exit()
```
初始化
```
    pygame.init()
    fpsClock = pygame.time.Clock()
```
创建显示层
```
    playSurface = pygame.display.set_mode((640,480))
    pygame.display.set_caption('Raspberry Snake')
```
初始化变量
```
    snakePosition = [100,100]
    snakeSegments = [[100,100],[80,100],[60,100]]
    raspberryPosition = [300,300]
    raspberrySpawned = 1
    direction = 'right'
    changeDirection = direction
```
检测事件
```
        for event in pygame.event.get():
            if event.type == QUIT:
                pygame.quit()
                sys.exit()
            elif event.type == KEYDOWN:
```
判断键盘事件
```
                if event.key == K_RIGHT or event.key == ord('d'):
                    changeDirection = 'right'
                if event.key == K_LEFT or event.key == ord('a'):
                    changeDirection = 'left'
                if event.key == K_UP or event.key == ord('w'):
                    changeDirection = 'up'
                if event.key == K_DOWN or event.key == ord('s'):
                    changeDirection = 'down'
                if event.key == K_ESCAPE:
                    pygame.event.post(pygame.event.Event(QUIT))
```
判断是否输入反方向
```
        if changeDirection == 'right' and not direction == 'left':
            direction = changeDirection
        if changeDirection == 'left' and not direction == 'right':
            direction = changeDirection
        if changeDirection == 'up' and not direction == 'down':
            direction = changeDirection
        if changeDirection == 'down' and not direction == 'up':
            direction = changeDirection
```
根据方向移动蛇头
```
        if direction == 'right':
            snakePosition[0] += 20
        if direction == 'left':
            snakePosition[0] -= 20
        if direction == 'up':
            snakePosition[1] -= 20
        if direction == 'down':
            snakePosition[1] += 20
```
增加蛇的长度
```
        snakeSegments.insert(0,list(snakePosition))
```
判断是否吃掉树莓
```
        if snakePosition[0] == raspberryPosition[0] and snakePosition[1] == raspberryPosition[1]:
            raspberrySpawned = 0
        else:
            snakeSegments.pop()
```
若吃掉树莓则重新生成树莓
```
        if raspberrySpawned == 0:
            x = random.randrange(1,32)
            y = random.randrange(1,24)
            raspberryPosition = [int(x*20),int(y*20)]
            raspberrySpawned = 1
```
绘制与刷新显示层
```        playSurface.fill(blackColour)
        for position in snakeSegments:
            pygame.draw.rect(playSurface,whiteColour,Rect(position[0],position[1],20,20))
            pygame.draw.rect(playSurface,redColour,Rect(raspberryPosition[0], raspberryPosition[1],20,20))

        pygame.display.flip()

```
判断是否死亡
```
        if snakePosition[0] > 620 or snakePosition[0] < 0:
            gameOver(playSurface)
        if snakePosition[1] > 460 or snakePosition[1] < 0:
            for snakeBody in snakeSegments[1:]:
                if snakePosition[0] == snakeBody[0] and snakePosition[1] == snakeBody[1]:
                    gameOver(playSurface)
```
## **作者**
甘睿