function solve(people, group, day ){
    let price;
    switch(group){
        case 'Students':
            if(day == 'Friday'){
                price = 8.45 * people;
            }
            else if (day == 'Saturday'){
                price = 9.80 * people;
            }
            else if (day == 'Sunday'){
                price = 10.46 * people;
            }
        break;
        case 'Business':
            if(day == 'Friday'){
                price = 10.90 * people;
            }
            else if (day == 'Saturday'){
                price = 15.60 * people;
            }
            else if (day == 'Sunday'){
                price = 16 * people;
            }
        break;
        case 'Regular':
            if(day == 'Friday'){
                price = 15 * people;
            }
            else if (day == 'Saturday'){
                price = 20 * people;
            }
            else if (day == 'Sunday'){
                price = 22.50 * people;
            }
        break;
    }
    if(group == 'Students' && people >= 30){
        price *= 0.85;
    }
    if(group == 'Business' && people >= 100){
        switch(day){
            case 'Friday':
                price = 10.90 * (people - 10);
            break;
            case 'Saturday':
                price = 15.60 * (people - 10);
            break;
            case 'Sunday':
                price = 16 * (people - 10);
            break;
        }
    }
    if(group == 'Regular' && (people >=10 && people <=20)){
        price *= 0.95;
    }

    console.log(`Total price: ${price.toFixed(2)}`);
}
solve(30, "Students", "Sunday");
solve(40, "Regular", "Saturday");