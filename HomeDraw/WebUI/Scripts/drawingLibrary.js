
function reconstructDrawingObject(draw, elementType, elementId, positionTop, positionLeft) {

    createElement(draw, elementType, elementId, positionTop, positionLeft);

    if (elementType === 'bathElement') {
        drawBath(elementType, elementId);
    }

    if (elementType === 'lavatoryElement') {
        drawLavatory(elementType, elementId);
    }

    if (elementType === 'showerElement') {
        drawShower(elementType, elementId);
    }

    if (elementType === 'doorElement') {
        drawDoor(elementType, elementId);
    }

    if (elementType === 'wallElement') {
        // Missing implementation
        drawWall(elementType, elementId);
    }

    if (elementType === 'windowElement') {
        drawWindow(elementType, elementId);
    }

    if (elementType === 'refrigeratorElement') {
        drawRefrigerator(elementType, elementId);
    }

    if (elementType === 'sinkElement') {
        drawSink(elementType, elementId);
    }

    if (elementType === 'stoveElement') {
        drawStove(elementType, elementId);
    }

    if (elementType === 'sofaElement') {
        drawSofa(elementType, elementId);
    }

    if (elementType === 'tableElement') {
        drawTable(elementType, elementId);
    }
}

function createElement(draw, elementType, elementId, positionTop, positionLeft) {
    var element = $('<div></div>', {
        style: 'width: ' + 100 + 'px; height: ' + 100 + 'px;',
        id: elementType + elementId
    });

    element.css("position", "absolute");
    element.attr("drawingElementType", elementType);

    if (positionTop !== null && positionLeft !== null) {
        element.css("top", positionTop);
        element.css("left", positionLeft);
    }

    $('#drawingSurface').append(element.draggable({
        containment: "parent",
        drag: function () {
            var position = element.offset();
            draw.server.moveElement(position.left, position.top, elementType + elementId);
        },
        stop: function () {
            var position = element.offset();
            draw.server.updateElement(position.left, position.top, elementId);
        }
    }));
}


function drawBath(elementType, elementId) {
    var x = 100;
    var y = 100;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var bathOuterRectangle = two.makeRectangle(0, 0, x, y);
    var bathInnerRoundedRectangle = two.makeRoundedRectangle(0, 0, x / 1.05, y / 1.111, 14);

    bathOuterRectangle.linewidth = 3;
    bathInnerRoundedRectangle.linewidth = 2;

    var bathInnerOuter = two.makeGroup(bathOuterRectangle, bathInnerRoundedRectangle);

    bathInnerOuter.translation.set(two.width / 2, two.height / 2);

    var bathTapTop = two.makeCircle(0, -x / 20, x / 20);
    var bathTapBottom = two.makeCircle(0, x / 20, x / 20);
    var bathTapRectangle = two.makeRectangle(x / 16, 0, x / 4.4, y / 10);
    var bathTap = two.makeGroup(bathTapTop, bathTapBottom, bathTapRectangle);

    bathTap.translation.set(two.width / 2 - bathOuterRectangle.height, two.height / 2);
    two.update();
}

function drawLavatory(elementType, elementId) {
    var x = 100;
    var y = x / 1.215;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var lavatoryOuterPath = two.makePath(-x / 2.025, 0, -x / 2.025, y / 2.5, x / 2.025, y / 2.5, x / 2.025, 0, x / 2.025, -y / 3.333, x / 4.05, -y / 2, -x / 4.05, -y / 2, -x / 2.025, -y / 3.333);
    var lavatoryInnerEllipse = two.makeEllipse(0, 0, x / 2.43, y / 2.85714285714);
    var lavatoryInnerOuter = two.makeGroup(lavatoryOuterPath, lavatoryInnerEllipse);

    lavatoryInnerOuter.translation.set(two.width / 2, two.height / 2);

    lavatoryOuterPath.linewidth = 3;
    lavatoryOuterPath.linewidth = 3;
    lavatoryInnerEllipse = 2;

    var lavatoryTapTop = two.makeCircle(-x / 8.86, -x / 16, x / 24.3, 12);
    var lavatoryTapBottom = two.makeCircle(-x / 8.86, x / 16, x / 24.3, 12);
    var lavatoryTapRectangle = two.makeRectangle(-x / 13.84375, 0, x / 5.4, y / 20);


    var lavatoryTap = two.makeGroup(lavatoryTapTop, lavatoryTapBottom, lavatoryTapRectangle);

    lavatoryTap.fill = 'grey';
    lavatoryTap.translation.set(two.width / 2, two.height / 2 + y / 4);
    lavatoryTap.rotation = -Math.PI / 2;

    two.update();
}

function drawShower(elementType, elementId) {
    var x = 100;
    var y = 100;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var showerOuterRectangle = two.makeRectangle(0, 0, x, y);
    var showerInnerRectangle = two.makeRectangle(0, 0, x / 1.07, y / 1.07);
    var showerBottomToUpLineLeft = two.makeLine(-x / 2, y / 2, x / 2, -y / 2);
    var showerBottomToUpLineRight = two.makeLine(x / 2, y / 2, -x / 2, -y / 2);

    showerOuterRectangle.linewidth = 3;
    showerOuterRectangle.linewidth = 2;

    var showerInnerOuter = two.makeGroup(showerOuterRectangle, showerInnerRectangle, showerBottomToUpLineLeft, showerBottomToUpLineRight);

    showerInnerOuter.translation.set(two.width / 2, two.height / 2);

    two.update();
}

function drawDoor(elementType, elementId) {
    var x = 100;
    var y = 100;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var doorLeftRectangle = two.makeRectangle(-x / 2, 0, x / 1.8, x / 18);
    var doorRightRectangle = two.makeRectangle(x / 2, 0, x / 1.8, x / 18);
    var doorLine = two.makeLine(-x / 4.5, 0, -x / 4.5, -x / 1.8);
    var doorCurve = two.makeCurve(-x / 4.5, -x / 1.8, -x / 5.14, -x / 1.8, -x / 6, -x / 1.8, x / 4.5, 0, true);


    doorLeftRectangle.linewidth = 3;
    doorRightRectangle.linewidth = 3;
    doorLine.linewidth = 3;

    var door = two.makeGroup(doorLeftRectangle, doorRightRectangle, doorLine, doorCurve);

    door.translation.set(two.width / 2, two.height / 2);

    two.update();
}

function drawWall(elementType, elementId) {

}

function drawWindow(elementType, elementId) {
    var x = 100;
    var y = x / 8.5714;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var windowMainRectangle = two.makeRectangle(0, 0, x, y);
    var windowRectangleCenter1 = two.makeRectangle(0, -y / 4.375, x / 2.14, y / 2);
    var windowRectangleCenter2 = two.makeRectangle(0, y / 4.375, x / 2.14, y / 2);
    var windowRectangleCenter3 = two.makeRectangle(0, y / 1.66, x / 1.2, y / 3.5);

    windowMainRectangle.linewidth = 3;
    windowRectangleCenter1.linewidth = 1;

    var windowGroup = two.makeGroup(windowMainRectangle, windowRectangleCenter1, windowRectangleCenter2, windowRectangleCenter3);

    windowGroup.translation.set(two.width / 2, two.height / 2);

    two.update();
}

function drawRefrigerator(elementType, elementId) {
    var x = 50;
    var y = x * 1.5;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var mainFridgeRectangle = two.makeRectangle(0, 0, x, y);
    var rightFridgeBlackRectangle = two.makeRectangle(x / 2, 0, x / 4, y);


    var fridgeHandle1 = two.makeCircle(x / 1.61, -y / 3, x / 20);
    var fridgeHandle2 = two.makeCircle(x / 1.61, -y / 3.75, x / 20);

    fridgeHandle1.fill = 'grey';
    fridgeHandle2.fill = 'grey';

    rightFridgeBlackRectangle.fill = 'black';

    var fridgeGroup = two.makeGroup(mainFridgeRectangle, rightFridgeBlackRectangle, fridgeHandle1, fridgeHandle2);

    fridgeGroup.translation.set(two.width / 2, two.height / 2);

    two.update();
}

function drawSink(elementType, elementId) {
    var x = 100;
    var y = x / 2.25;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var mainSinkRectangle = two.makeRectangle(0, 0, x - x / 2, y);
    var sinkRoundedRectangle = two.makeRoundedRectangle(0, 0, x / 2.7, x / 2.7, x / 18);

    mainSinkRectangle.linewidth = 3;
    sinkRoundedRectangle.linewidth = 2;

    var sinkGroup = two.makeGroup(mainSinkRectangle, sinkRoundedRectangle);

    sinkGroup.translation.set(two.width / 2, two.height / 2);

    var sinkTapTop = two.makeCircle(0, -y / 12, x / 27, 10);
    var sinkTapBottom = two.makeCircle(0, y / 12, x / 27, 12);
    var sinkTapRectangle = two.makeRectangle(x / 22.5, 0, x / 6, 10);
    var sinkTapGroup = two.makeGroup(sinkTapTop, sinkTapBottom, sinkTapRectangle);

    sinkTapGroup.fill = 'grey';
    sinkTapGroup.translation.set(two.width / 2, two.height / 2 + y / 2.18);
    sinkTapGroup.rotation = -Math.PI / 2;

    two.update();
}

function drawStove(elementType, elementId) {
    var x = 100;
    var y = x;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var mainStoveRectangle = two.makeRectangle(0, 0, x, y);
    var leftStoveRectangle = two.makeRectangle(-x / 2, 0, x / 6.6, y);

    var topLeftCircle = two.makeCircle(-x / 5, -y / 4, x / 5);
    var bottomLeftCircle = two.makeCircle(-x / 5, y / 5, x / 5);

    var topRightCircle = two.makeCircle(x / 4, -y / 4, x / 5.714);
    var bottomRightCircle = two.makeCircle(x / 4, y / 4, x / 5.714);

    mainStoveRectangle.linewidth = 2;
    leftStoveRectangle.linewidth = 3;

    var sinkGroup = two.makeGroup(mainStoveRectangle, leftStoveRectangle, topLeftCircle, bottomLeftCircle, topRightCircle, bottomRightCircle);

    sinkGroup.translation.set(two.width / 2, two.height / 2);

    two.update();
}

function drawSofa(elementType, elementId) {
    var x = 100;
    var y = x / 3;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var mainSofaRoundedRect = two.makeRoundedRectangle(0, 0, x, y, x / 30);
    var sofaTopRect = two.makeRectangle(0, -y / 2, x / 0.88, y / 5);
    var sofaLeftRect = two.makeRectangle(-x / 1.875, 0, x / 15, y * 1.2);
    var sofaRightRect = two.makeRectangle(x / 1.875, 0, x / 15, y * 1.2);

    mainSofaRoundedRect.linewidth = 3;
    sofaTopRect.linewidth = 3;
    sofaLeftRect.linewidth = 3;
    sofaRightRect.linewidth = 3;

    var sofaMiddle = two.makeLine(0, -y / 2, 0, y / 2);

    var sofaLeftPillow = two.makeRoundedRectangle(-x / 3.75, y / 20, x / 3.333, y / 1.25, x / 30);
    var sofaRightPillow = two.makeRoundedRectangle(x / 3.75, y / 20, x / 3.333, y / 1.25, x / 30);

    var sofaGroup = two.makeGroup(mainSofaRoundedRect, sofaMiddle, sofaLeftPillow, sofaRightPillow, sofaTopRect, sofaLeftRect, sofaRightRect);

    sofaGroup.translation.set(two.width / 2, two.height / 2);

    two.update();
}

function drawTable(elementType, elementId) {
    var x = 100;
    var y = x / 2;

    var elem = document.getElementById(elementType + elementId);
    var params = { width: x, height: y };
    var two = new Two(params).appendTo(elem);

    var mainTableRect = two.makeRectangle(0, 0, x, y);

    var tableChairTopLeft = two.makeRoundedRectangle(-x / 3.33, -y / 1.25, x / 3.33, y / 2.5, x / 20);
    var tableChairTopRight = two.makeRoundedRectangle(x / 3.33, -y / 1.25, x / 3.33, y / 2.5, x / 20);

    var tableChairBottomLeft = two.makeRoundedRectangle(-x / 3.33, y / 1.25, x / 3.33, y / 2.5, x / 20);
    var tableChairBottomRight = two.makeRoundedRectangle(x / 3.33, y / 1.25, x / 3.33, y / 2.5, x / 20);

    mainTableRect.linewidth = 3;

    var tableGroup = two.makeGroup(mainTableRect, tableChairTopLeft, tableChairTopRight, tableChairBottomLeft, tableChairBottomRight);

    tableGroup.translation.set(two.width / 2, two.height / 2);

    two.update();
}