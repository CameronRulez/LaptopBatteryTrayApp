from PIL import Image, ImageDraw, ImageFont
import os

fontsFolder = 'C:/Windows/Fonts'
my_font = ImageFont.truetype(os.path.join(fontsFolder, 'segoeui.ttf'), 82)
WIDTH, HEIGHT = (128, 128)

for i in range(100):
	im = Image.new('RGBA', (WIDTH, HEIGHT), (255,0,0,0))
	draw = ImageDraw.Draw(im)
	
	msg = str(i+1)
	text_w, text_h = draw.textsize(msg, font=my_font)
	draw.text( ((WIDTH - text_w) / 2, (HEIGHT - text_h) / 2), msg, fill='white', font=my_font)
	im.save('Resources/battery-'+ msg +'.ico',sizes=[(32,32)])