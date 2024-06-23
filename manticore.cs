// one player controls an airship called the Manticore, and another player controls the defenses of a city called Consolas that the
// airship is attacking

Console.WriteLine("Manticore, what position will you take to begin your bombardment of Consolas?");
int shipDistance = AskForNumberInRange("Your cannon is powerful and can target the city from up to one hundred miles away.", 1, 100);
Console.WriteLine($"{shipDistance} miles away is a good position.  Now it's the defenders' turn.");
Console.Beep(37, 2000); // menacing; lets the pilot see the above message before the screen is cleared
Console.Clear();

int shipHP = 10;
int cityHP = 15;
int round = 1;
int target;

while (shipHP > 0 && cityHP > 0)
{
    Console.WriteLine($"ROUND {round}");
    Console.WriteLine($"Consolas barrier: {cityHP:00}/15   Manticore hull: {shipHP:00}/10");
    DefenderAttack();
    if ( shipHP > 0 )
    {
        Console.WriteLine("The Manticore fires on the magical barrier of Consolas!");
        cityHP -= 1;
    }
    if (cityHP > 0 && shipHP > 0) // the round divider only appears if another round is beginning
    {
        Console.WriteLine("_________________________________________________________________________________________");
        Console.WriteLine("");
    }
    round++;
}

Console.WriteLine("");

if (shipHP <= 0)
{
    Console.WriteLine("The nose of the Manticore finally begins to dip...and it comes crashing down to the earth!");
    Console.WriteLine("The city of Consolas has survived!");
}

else if (cityHP <= 0)
{
    Console.WriteLine("...and finally, it flickers and fades away, leaving the city utterly defenseless to the Manticore's barrage.");
    Console.WriteLine("Consolas's last survivors scatter and flee from the terrible, thundering laugh of the Uncoded One.");
}    



// methods
void DefenderAttack()
{
    int attackType = CannonAttackType(round);
    int damage = CannonDamage(attackType);
    Console.Write($"The magic cannon will do {damage} damage this round if it hits.  Where will you target it?  ");
    target = int.Parse(Console.ReadLine());
    if (target > shipDistance) Console.WriteLine("Whiff!  You shot past it!");
    else if (target < shipDistance) Console.WriteLine("You undershot that one!");
    else if (target == shipDistance)
    {
        if (attackType == 4)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You hit the Manticore with a GIANT LASER BEAM!");
            Console.ForegroundColor = ConsoleColor.White;
            shipHP -= 10;
        }
        else if (attackType == 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You hit the Manticore with a crackling bolt of lightning!");
            Console.ForegroundColor = ConsoleColor.White;
            shipHP -= 3;
        }
        else if (attackType == 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You hit the Manticore with a sizzling fireball!");
            Console.ForegroundColor = ConsoleColor.White;
            shipHP -= 3;
        }
        else
        {
            Console.WriteLine("You hit the Manticore!");
            shipHP -= 1;
        }
    }
}

// a return value of 1 is a standard attack, 2 is a fireball, 3 is a lightning bolt, 4 is a giant laser beam
int CannonAttackType(int shot)
{
    if (shot % 3 == 0 && shot % 5 == 0) return 4;
    else if (shot % 5 == 0) return 3;
    else if (shot % 3 == 0) return 2;
    else return 1;
}

// determines how much damage each of the defender's attacks does
int CannonDamage(int attack)
{
    if (attack == 4) return 10;
    else if (attack == 3 || attack == 2) return 3;
    else return 1;
}

int AskForNumberInRange(string question, int lowEnd, int highEnd)
{
    Console.WriteLine(question); // the parameter string should inform the user of the required range
    while (true)
    {
        int answer = int.Parse(Console.ReadLine());
        if (answer >= lowEnd && answer <= highEnd) return answer;
        Console.WriteLine($"Type a number from {lowEnd} to {highEnd}.");
    }

}
