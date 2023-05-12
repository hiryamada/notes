from flask import Flask, request, redirect, render_template
from azure.identity import DefaultAzureCredential
from azure.storage.blob import BlobServiceClient, BlobClient, ContainerClient
from werkzeug.utils import secure_filename


app = Flask(__name__)

account_url = "https://images29384.blob.core.windows.net"
default_credential = DefaultAzureCredential()
images_container = ContainerClient(account_url, 'images', credential=default_credential)


@app.route("/")
def index():
    blobs = images_container.list_blobs()
    return render_template('index.html', blobs=blobs, account_url=account_url)

@app.route("/upload")
def upload():
    return render_template('upload.html')

@app.route("/upload_image", methods=['POST'])
def upload_image():
    if 'file' not in request.files:
        return redirect(request.url)
    file = request.files['file']
    if file.filename == '':
        return redirect(request.url)
    if file:
        filename = secure_filename(file.filename)
        images_container.upload_blob(name=filename, data=file.stream, overwrite=True)
    return redirect('/')


if __name__ == "__main__":
    app.run()
