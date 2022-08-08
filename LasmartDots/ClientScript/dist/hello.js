export var funcs;
(function (funcs) {
    function hello() {
        const message = 'Hello world!';
        console.log(message);
    }
    funcs.hello = hello;
})(funcs || (funcs = {}));
