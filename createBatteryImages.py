from PIL import Image, ImageDraw, ImageFont
import os
for i in range(1):#01):
	im = Image.new('RGBA', (128, 128), (255,0,0,0))
	#im = Image.open('battery-bg.png')
	draw = ImageDraw.Draw(im)
	fontsFolder = 'C:/Windows/Fonts'
	font = ImageFont.truetype(os.path.join(fontsFolder, 'segoeui.ttf'), 85)
	draw.text((-10,0), '100', fill='white', font=font)
	im.save('battery'+'101'+'.ico',sizes=[(32,32)])


# img = Image.open('battery-bg2.png')
# img = img.convert("RGBA")
# datas = img.getdata()

# newData = []
# for item in datas:
#     if item[0] > 0 and item[1] > 0 and item[2] > 0:
#         newData.append((255, 255, 255, 0))
#     else:
#         newData.append((200, 220, 220))

# img.putdata(newData)
# img.save("battery-bg3.png", "png")