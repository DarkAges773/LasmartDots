import Konva from "konva";
var $ = require("jquery");
export var LasmartDots;
(function (LasmartDots) {
    class Dot {
    }
    LasmartDots.Dot = Dot;
    class Comment {
    }
    LasmartDots.Comment = Comment;
    class Canvas {
        constructor(containerId) {
            this.containerId = containerId;
            this.refreshCanvas();
        }
        refreshCanvas() {
            $.ajax({
                method: "GET",
                url: "/Dots/",
                dataType: "json"
            }).done((dots) => {
                this.fillCanvas(dots);
            });
        }
        fillCanvas(dots) {
            let width = window.innerWidth * 0.5;
            let height = window.innerHeight * 0.5;
            let stage = new Konva.Stage({
                container: this.containerId,
                width: width,
                height: height
            });
            this.plotDots(dots);
            stage.add(this.layer);
        }
        plotDots(dots) {
            this.layer = new Konva.Layer();
            dots.forEach(dot => {
                let posX = dot.posX;
                let posY = dot.posY;
                let circle = new Konva.Circle({
                    x: posX,
                    y: posY,
                    radius: dot.radius,
                    fill: dot.color,
                });
                circle.on('pointerdblclick ', () => {
                    $.ajax({
                        method: "DELETE",
                        url: "/Dots/" + dot.id,
                    }).done(() => {
                        this.refreshCanvas();
                    });
                });
                this.layer.add(circle);
                posY += dot.radius;
                this.plotComments(dot.comments, posX, posY);
            });
        }
        plotComments(comments, posX, posY) {
            const commentMargin = 5;
            comments.forEach(comment => {
                posY += commentMargin;
                let text = new Konva.Text({
                    x: posX,
                    y: posY,
                    padding: 5,
                    text: comment.text,
                    fontSize: 10,
                    align: "center"
                });
                let rect = new Konva.Rect({
                    x: posX,
                    y: posY,
                    height: text.height(),
                    width: text.width(),
                    fill: comment.backgroundColor
                });
                text.offsetX(text.width() / 2);
                rect.offsetX(rect.width() / 2);
                this.layer.add(rect, text);
                posY += rect.height();
            });
        }
    }
    LasmartDots.Canvas = Canvas;
})(LasmartDots || (LasmartDots = {}));
