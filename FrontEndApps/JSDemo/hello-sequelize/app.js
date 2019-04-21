const Sequelize = require('sequelize');
const config = require('./config');

var sequelize = new Sequelize(config.database, config.username, config.password,
    {
        host: config.host,
        dialect: 'mysql',
        pool: {
            max: 5,
            min: 5,
            idle: 30000
        }
    });

var Pet = sequelize.define('pet',
    {
        id: {
            type: Sequelize.STRING(50),
            primaryKey: true
        },
        name: Sequelize.STRING(100),
        gender: Sequelize.BOOLEAN,
        birth: Sequelize.STRING(10),
        createdAt: Sequelize.BIGINT,
        updatedAt: Sequelize.BIGINT,
        version: Sequelize.BIGINT
    },
    {
        timestamps: false
    });

var now = Date.now();

Pet.create({
    id: 'g-' + now,
    name: 'Caffey',
    gender: false,
    birth: '2010-09-09',
    createdAt: now,
    updatedAt: now,
    version: 0
}).then(function (p) {
    console.log('created: ' + JSON.stringify(p));
}).catch(function (err) {
    console.log('failed: ' + err);
});

(async () => {
    try {
        var dog = await Pet.create({
            id: 'g-' + now,
            name: 'Odie',
            gender: false,
            birth: '2018-08-18',
            createdAt: now,
            updatedAt: now,
            version: 0
        });
        console.log('created: ' + JSON.stringify(dog));
    } catch (err) { }
})();

(async () => {
    var pets = await Pet.findAll({
        where: {
            name: 'Caffey'
        }
    });
    console.log(`find ${pets.length} pets:`);

    if (pets.length === 0) return;

    for (let p of pets) {
        console.log(JSON.stringify(p));

        // 更新记录
        console.log(`update pet ...`);

        p.gender = true;
        p.updatedAt = Date.now();
        p.version++;
        await p.save();

        if (p.version === 3) {
            await p.destroy();
            console.log(`${p.name} was destroyed.`);
        }
    }
})();