import qrcode

qr = qrcode.make("100")

qr.save("qr_100.png")

print("QR code created successfully!")