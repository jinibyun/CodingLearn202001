/// <reference path = "tu_10_namespace.ts" /> 
var Drawing;
(function (Drawing) {
    var Circle = /** @class */ (function () {
        function Circle() {
        }
        Circle.prototype.draw = function () {
            console.log("Circle is drawn");
        };
        return Circle;
    }());
    Drawing.Circle = Circle;
})(Drawing || (Drawing = {}));
