var fn_index = async (ctx, next) => {
    ctx.render('index.html', { title: 'Welcome' });
};

module.exports = [
    {
        method: 'GET',
        path: '/',
        func: fn_index
    }
];