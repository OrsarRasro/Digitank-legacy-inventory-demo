/* jQuery placeholder */
window.jQuery = window.$ = function(selector) {
    return {
        ready: function(fn) { if (document.readyState === 'complete') fn(); else document.addEventListener('DOMContentLoaded', fn); },
        click: function(fn) { return this; },
        val: function() { return ''; },
        html: function() { return ''; }
    };
};