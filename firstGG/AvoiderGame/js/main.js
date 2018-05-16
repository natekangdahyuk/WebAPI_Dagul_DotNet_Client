var globalAvatarImage = new Image();
var globalEnemyImage = new Image();
globalAvatarImage.src = "img/avatar.png";
globalEnemyImage.src = "img/enemy.png";

function drawAvatar() {
    var gameCanvas = document.getElementById("gameCanvas");
    var avatarImage = globalAvatarImage;

    gameCanvas.getContext("2d").drawImage(avatarImage, Math.random() * 100, Math.random() * 100);

    gameCanvas.addEventListener("mousemove", redrawAvatar);
}

function redrawAvatar(mouseEvent) {
    var gameCanvas = document.getElementById("gameCanvas");
    var avatarImage = globalAvatarImage;
    var enemyImage = globalEnemyImage;

    gameCanvas.width = 400;
    //gameCanvas.getContext("2d").drawImage(avatarImage, mouseEvent.offsetX, mouseEvent.offsetY);
    //gameCanvas.getContext("2d").drawImage(enemyImage, 250, 150);

    //var gameCanvas = document.getElementById("gameCanvas");
    //var avatarImage = globalAvatarImage;
    //var enemyImage = globalEnemyImage;



    //gameCanvas.width = 400;		//this erases the contents of the canvas
    gameCanvas.getContext("2d").drawImage(avatarImage, mouseEvent.offsetX, mouseEvent.offsetY);
    gameCanvas.getContext("2d").drawImage(enemyImage, 250, 150);

    if (mouseEvent.offsetX > 220 && mouseEvent.offsetX < 280 && mouseEvent.offsetY > 117 && mouseEvent.offsetY < 180) {
        alert("You hit the enemy!");
    }

}
