function farmManagement(input) {
    let farmers = new Map();
    let n = Number(input.shift());

    for (let i = 0; i < n; i++) {
        let [name, area, taskList] = input[i].split(' ');
        let tasks = taskList.split(',');
        farmers.set(name, {
            area: area,
            tasks: tasks
        });
    }

    for (let i = n; i < input.length; i++) {
        if (input[i] === 'End') break;

        let [command, ...params] = input[i].split(' / ');

        switch (command) {
            case 'Execute':
                executeTask(params[0], params[1], params[2]);
                break;
            case 'Change Area':
                changeArea(params[0], params[1]);
                break;
            case 'Learn Task':
                learnTask(params[0], params[1]);
                break;
        }
    }

    for (let [name, info] of farmers) {
        console.log(`Farmer: ${name}, Area: ${info.area}, Tasks: ${info.tasks.sort().join(', ')}`);
    }

    function executeTask(farmerName, workArea, task) {
        let farmer = farmers.get(farmerName);
        if (farmer.area === workArea && farmer.tasks.includes(task)) {
            console.log(`${farmerName} has executed the task: ${task}!`);
        } else {
            console.log(`${farmerName} cannot execute the task: ${task}.`);
        }
    }

    function changeArea(farmerName, newArea) {
        let farmer = farmers.get(farmerName);
        farmer.area = newArea;
        console.log(`${farmerName} has changed their work area to: ${newArea}`);
    }

    function learnTask(farmerName, newTask) {
        let farmer = farmers.get(farmerName);
        if (farmer.tasks.includes(newTask)) {
            console.log(`${farmerName} already knows how to perform ${newTask}.`);
        } else {
            farmer.tasks.push(newTask);
            console.log(`${farmerName} has learned a new task: ${newTask}.`);
        }
    }
}
