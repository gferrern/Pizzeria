const express = require('express')
const upload  = require('multer')();
const app = express()
const port = 3000

app.get('/', upload.any(),(req, res) => {
    res.end(JSON.stringify([
        "ruta1",
        "ruta2",
        "ruta3",
        "ruta4",
    ]));
});

app.listen(port, () => console.log(`Example app listening on port ${port}!`))