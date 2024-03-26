var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext("2d");
var image = new Image();
var dotRadius = 10;
var x = [123, 542, 876, 567];
var y = [233, 442, 776, 867];

var dotX = 267; // Vị trí X của chấm đỏ
var dotY = 150; // Vị trí Y của chấm đỏ

// Tải ảnh
image.onload = function () {
    canvas.width = image.width;
    canvas.height = image.height;
    ctx.drawImage(image, 0, 0);

    // Vẽ chấm đỏ
    ctx.beginPath();
    ctx.arc(dotX, dotY, dotRadius, 0, 2 * Math.PI);
    ctx.fillStyle = 'red';
    ctx.fill();

    // Vẽ các điểm
    for (var i = 0; i < x.length; i++) {
        ctx.beginPath();
        ctx.arc(x[i], y[i], dotRadius, 0, 2 * Math.PI);
        ctx.fillStyle = 'blue';
        ctx.fill();
    }
    // Bắt sự kiện click
    canvas.addEventListener('click', function (event) {
        var rect = canvas.getBoundingClientRect();
        var x = event.clientX - rect.left;
        var y = event.clientY - rect.top;
        
        // Kiểm tra nếu click vào chấm đỏ
        if (Math.pow(x - dotX, 2) + Math.pow(y - dotY, 2) < Math.pow(dotRadius, 2)) {
            console.log("You clicked on the red dot!");
            // Ở đây bạn có thể xử lý đường dẫn của chấm đỏ
            window.location.href = '/WorkShifts/Index';
        }
        
        // Kiểm tra nếu click vào các chấm xanh
        for (var i = 1; i < x.length; i++) {
            if (Math.pow(x - x[i], 2) + Math.pow(y - y[i], 2) < Math.pow(dotRadius, 2)) {
                console.log("You clicked on the blue dot at index " + i + "!");
                // Ở đây bạn có thể xử lý đường dẫn của các chấm xanh
                window.location.href = '/WorkShifts/Details' + i;
            }
        }
    });
}
image.src = '/images/mapQv.png';
// Bắt sự kiện click trên màn hình điện thoại
canvas.addEventListener('touchstart', function (event) {
    var rect = canvas.getBoundingClientRect();
    var x = event.touches[0].clientX - rect.left;
    var y = event.touches[0].clientY - rect.top;

    handleTouchClick(x, y);
});

// Bắt sự kiện click trên máy tính bảng
canvas.addEventListener('click', function (event) {
    var rect = canvas.getBoundingClientRect();
    var x = event.clientX - rect.left;
    var y = event.clientY - rect.top;

    handleClick(x, y);
});

function handleClick(x, y) {
    // Kiểm tra nếu click vào chấm đỏ
    if (Math.pow(x - dotX, 2) + Math.pow(y - dotY, 2) < Math.pow(dotRadius, 2)) {
        console.log("You clicked on the red dot!");
        // Ở đây bạn có thể xử lý đường dẫn của chấm đỏ
        window.location.href = '/WorkShifts/Index';
        return;
    }

    // Kiểm tra nếu click vào các chấm xanh
    for (var i = 0; i < x.length; i++) {
        if (Math.pow(x - x[i], 2) + Math.pow(y - y[i], 2) < Math.pow(dotRadius, 2)) {
            console.log("You clicked on the blue dot at index " + i + "!");
            // Ở đây bạn có thể xử lý đường dẫn của các chấm xanh
            window.location.href = '/WorkShifts/Details' + i;
            return;
        }
    }
}

function handleTouchClick(x, y) {
    // Kiểm tra nếu click vào chấm đỏ
    if (Math.pow(x - dotX, 2) + Math.pow(y - dotY, 2) < Math.pow(dotRadius, 2)) {
        console.log("You clicked on the red dot!");
        // Ở đây bạn có thể xử lý đường dẫn của chấm đỏ
        window.location.href = '/Home/Privacy';
        return;
    }

    // Kiểm tra nếu click vào các chấm xanh
    for (var i = 0; i < x.length; i++) {
        if (Math.pow(x - x[i], 2) + Math.pow(y - y[i], 2) < Math.pow(dotRadius, 2)) {
            console.log("You clicked on the blue dot at index " + i + "!");
            // Ở đây bạn có thể xử lý đường dẫn của các chấm xanh
            window.location.href = '/Home/Privacy' + i;
            return;
        }
    }
}

