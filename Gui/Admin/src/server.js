const http = require('http');
const fs = require('fs');

const path = require('path');
const createPath = (page) => path.resolve(__dirname, 'views', `${page}.html`);

const server = http.createServer(function (req, res) {
    res.setHeader('Content-Type', 'text/html');

    let basePath = '';
    switch (req.url) {
        case '/':
        case '/home':
        case '/index':
            basePath = createPath('index');
            break;
        case '/users':
            basePath = createPath('users');
            break;
        default:
            basePath = createPath('index');
            break;
    }

    fs.readFile(basePath, function (err, data) {
        if (err) {
            res.writeHead(404);
        } else {
            res.write(data);
        }
        res.end();
    });

    includeCss(req, res);
    includeJs(req, res);
});

function includeCss(request, response) {
    if (request.url.indexOf(".css") !== -1) {
        var file = fs.readFileSync(`.${request.url}`, { 'encoding': 'utf8' });
        response.writeHead(200, { 'Content-Type': 'text/css' });
        response.write(file);
        response.end();
    }
}

function includeJs(request, response) {
    if (request.url.indexOf(".js") !== -1) {
        var file = fs.readFileSync(`.${request.url}`, { 'encoding': 'utf8' });
        response.writeHead(200, { 'Content-Type': 'text/javascript ' });
        response.write(file);
        response.end();
    }
}

const port = 3000;
server.listen(port, function (error) {
    if (error) {
        console.log('Server error: ' + error);
    } else {
        console.log('Server is listening on port ' + port);
    }
});