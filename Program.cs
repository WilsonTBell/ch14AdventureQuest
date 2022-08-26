using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Robe BestFit = new Robe
            {
                Length = 52,
                Colors = new List<string> { "purple", "orange", "green" }
            };

            Hat CoolHat = new Hat
            {
                ShininessLevel = 6
            };

            Prize CoolestPrize = new Prize("You've won a FREE chocolate factory full of enslaved little people!!");

            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge IndianaJones = new Challenge(
                @"What is the best Indiana Jones film?
                1) Raiders of the Lost Ark
                2) Temple of Doom
                3) The Last Crusade
                4) Kingdom of the Crystal Skull", 1, 25);

            Challenge BrownieTemp = new Challenge(
                "What is the ideal oven temperature for brownies?", 350, 20
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            Console.WriteLine("What do they call you adventurer?");

            string userName = Console.ReadLine();

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(userName, BestFit, CoolHat);

            Console.WriteLine(theAdventurer.GetDescription());
            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                IndianaJones,
                BrownieTemp
            };

            List<Challenge> FindAvailableChallenges(List<Challenge> allChallenges)
            {
                List<Challenge> NewChallenges = new List<Challenge>();

                for (int i = 0; i < 5; i++)
                {
                    int ChallengeSelector = new Random().Next(0, 7);

                    NewChallenges.Add(allChallenges[ChallengeSelector]);
                }

                return NewChallenges;
            }

            int SuccessCounter = 0;

            // Loop through all the challenges and subject the Adventurer to them

            void theQuest()
            {
                if (SuccessCounter > 0)
                {
                    theAdventurer.Awesomeness += (SuccessCounter * 10);
                    SuccessCounter = 0;
                }

                List<Challenge> availableChallenges = FindAvailableChallenges(challenges);

                foreach (Challenge challenge in availableChallenges)
                {
                    challenge.RunChallenge(theAdventurer, SuccessCounter);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                CoolestPrize.ShowPrize(theAdventurer);

                Console.WriteLine("Do you want to quest again? y/n");

                string answer = Console.ReadLine();

                if (answer == "y")
                {
                    theQuest();
                }
            }

            theQuest();

        }
    }
}
