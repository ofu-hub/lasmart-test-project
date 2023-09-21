// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DrawContainer() {
    $.ajax({
        type: 'GET',
        url: '/Point/Get',
        success: function (response) {
            Draw(response);
        },
        error: function (error) {
            console.log(error)
            alert('Error');
        }
    });
}

function Draw(response) {
    var width = window.innerWidth;
    var height = window.innerHeight;

    var stage = new Konva.Stage({
        container: 'container',
        width: width,
        height: height,
    });
    
    var layer = new Konva.Layer();

    const xSnaps = Math.round(stage.width() / 100);
    const ySnaps = Math.round(stage.height() / 100);
    const cellWidth = stage.width() / xSnaps;
    const cellHeight = stage.height() / ySnaps;

    for (var i = 0; i < xSnaps; i++) {
        layer.add(
            new Konva.Line({
                x: i * cellWidth,
                points: [0, 0, 0, stage.height()],
                stroke: 'rgba(0, 0, 0, 0.2)',
                strokeWidth: 1,
            })
        );
    }

    for (var i = 0; i < ySnaps; i++) {
        layer.add(
            new Konva.Line({
                y: i * cellHeight,
                points: [0, 0, stage.width(), 0],
                stroke: 'rgba(0, 0, 0, 0.2)',
                strokeWidth: 1,
            })
        );
    }
    
/*    stage.on('pointermove', function () {
        var pointerPos = stage.getPointerPosition();
        var x = pointerPos.x;
        var y = pointerPos.y;
        console.log('x: ' + x + ', y: ' + y);
    });*/
    
    for (var i = 0; i < response.length; i++) {
        var group = new Konva.Group({
            draggable: true
        });
        var circle = new Konva.Circle({
            id: response[i].id,
            x: response[i].positionX,
            y: response[i].positionY, 
            radius: response[i].radius,
            fill: response[i].color,
            name: response[i].id + '',
        })

        circle.on(('mouseup'), function (e) {
            var pos = group.getRelativePointerPosition();
            var id = e.currentTarget.attrs.id;
            const point = {
                Id: id,
                PositionX: parseInt(pos.x),
                PositionY: parseInt(pos.y),
            };
            console.log(circle);
            console.log(id, 'mouse x: ' + pos.x + ', mouse y: ' + pos.y);
            console.log(point);
            $.ajax({
                url: '/Point/Update',
                method: 'POST',
                dataType: 'html',
                data: point,
                success: function (response) {
                    if (!response) {
                        alert("Error")
                    }
                }
            });
        })
        
        circle.on('dblclick', function (e) {
            var id = e.currentTarget.attrs.name;
            $.ajax({
                url: "/Point/Delete",
                type: "DELETE",
                datatype: "text",
                data: { Id: id },
                success: function (response) {
                    if (response) {
                        var shapes = stage.find('.' + id);
                        for (var i = 0; i < shapes.length; i++) {
                            shapes[i].destroy();
                        }
                        layer.draw();
                    } else { alert("Error") }
                }
            });
        })
        group.add(circle)
        var starPosition = response[i].positionY + response[i].radius + 5;
        for (var j = 0; j < response[i].comments.length; j++) {
            var simpleLabel = new Konva.Label({
                x: (response[i].positionX - (response[i].comments[j].text.length * 5.1)),
                y: starPosition,
                opacity: 0.75,
            });

            simpleLabel.add(
                new Konva.Tag({
                    fill: response[i].comments[j].color,
                    stroke: "Grey",
                    name: response[i].id + ''
                })
            );

            simpleLabel.add(
                new Konva.Text({
                    text: response[i].comments[j].text,
                    fontFamily: 'Calibri',
                    fontSize: 18,
                    padding: 5,
                    fill: 'Green',
                    name: response[i].id + ''
                })
            );
            group.add(simpleLabel)
            starPosition += 32;
        }
        layer.add(group);
    }
    stage.add(layer);
}