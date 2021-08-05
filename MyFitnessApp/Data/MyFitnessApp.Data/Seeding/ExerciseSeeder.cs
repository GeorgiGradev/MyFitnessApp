namespace MyFitnessApp.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyFitnessApp.Data.Models;

    public class ExerciseSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Exercises.Any())
            {
                return;
            }

            var exercises = new List<Exercise>
            {
               new Exercise
               {
                  // SHOULDERS
                  Name = "Seated Arnold Press",
                  Description = "Keep your back flat against the pad throughout the duration of the exercise. Don’t allow the head to jut forward excessively. Drive the biceps to the ear and exhale as you press. If you sense any pressure in your neck or traps during the movement, look to address a lack of thoracic spine extension or shoulder flexion. Keeping the elbows slightly bent at the top and not locking out entirely will help to keep tension on the shoulders. If you can’t lock out the elbows overhead than it may indicate a lack of shoulder mobility due to poor scapular upward rotation.",
                  EquipmentId = 11, // Dumbbell
                  CategoryId = 1, // Shoulder
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-arnold-press-thumb.jpg",
                  VideoUrl = "https://www.youtube.com/embed/hmnZKRpYaV8",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Seated Barbell Shoulder Press",
                  Description = "Adjust the barbell to just below shoulder height while standing then load the desired weight onto the bar. Place an adjustable bench beneath the bar in an upright position. Sit down on the bench and unrack the bar using a pronated grip. Inhale, brace, tuck the chin, then lower the bar to the top of your chest. Exhale and press the bar back to lockout. Repeat for the desired number of repetitions.",
                  EquipmentId = 11, // Dumbbell
                  CategoryId = 1, // Shoulder
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-shoulder-press-1.jpg",
                  VideoUrl = "https://www.youtube.com/embed/Gxhx7GpRb5g",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Military Press (AKA Overhead Press)",
                  Description = "Adjust the barbell to just below shoulder height then load the desired weight onto the bar. Assume a shoulder width stance and place your hands at (or just outside of) shoulder width with a pronated grip on the bar. Step underneath the bar and unrack it while keeping the spine in a neutral position. Take two steps back, inhale, brace, tuck the chin, then press the bar to lockout overhead. Exhale once the bar gets to lockout and reverse the movement slowly while controlling the bar back to your chest. Repeat for the desired number of repetitions.",
                  EquipmentId = 10, // Barbell
                  CategoryId = 1, // Shoulder
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/military-overhead-press.jpg",
                  VideoUrl = "https://www.youtube.com/embed/j7ULT6dznNc",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Machine Shoulder Press",
                  Description = "Assume a seated position in the machine with the handles set at roughly shoulder height. Grab the handles with a pronated or neutral grip. Inhale and press directly overhead. Slowly lower the handles back to the starting position. Repeat for the desired number of repetitions.",
                  EquipmentId = 9, // Machine
                  CategoryId = 1, // Shoulder
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/machine-shoulder-press.jpg",
                  VideoUrl = "https://www.youtube.com/embed/fj_VAk1jfZ8",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Single Arm Cable Lateral Raise (Crossbody)",
                  Description = "Position a cable at the lowest position possible and attach a single handle. Reach across your body and grab the handle with a neutral grip. Keep the elbow slightly bent and pull the handle across your body and raise laterally. Slowly lower the handle back to the starting position under control. Repeat for the desired number of repetitions.",
                  EquipmentId = 8, // Cable
                  CategoryId = 1, // Shoulder
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/single-arm-cable-lateral-raise.jpg",
                  VideoUrl = "https://www.youtube.com/embed/Fv-eAW1uKDI",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },

               // TRICEPS
               new Exercise
               {
                  Name = "EZ Bar Skullcrusher",
                  Description = "Select your desired weight and sit on the edge of a flat bench. To get into position, lay back and keep the bar close to your chest. Once you are supine, press the weight to lockout. Lower the weights towards your head by unlocking the elbows and allowing the ez bar to drop toward your forehead or just above. Once your forearms reach parallel or just below, reverse the movement by extending the elbows while flexing the triceps to lockout the weight. Repeat for the desired number of repetitions.",
                  EquipmentId = 10, // Barbell
                  CategoryId = 2, // Triceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/ez-bar-skullcrusher_0.jpg",
                  VideoUrl = "https://www.youtube.com/embed/K6MSN4hCDM4",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Straight Bar Triceps Extension",
                  Description = "The straight bar triceps extension is a variation of the cable triceps extension and an exercise used to build the muscles of the triceps. Well-built triceps also have a lot of positive carryover into your pressing movements such as bench press variations and shoulder press variations. The straight bar triceps extension can be included in your triceps workouts, upper body workouts, push workouts, and full body workouts.",
                  EquipmentId = 8, // Cable
                  CategoryId = 2, // Triceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/straight-bar-tricep-extension-1.jpg",
                  VideoUrl = "https://www.youtube.com/embed/mpZ9VRisAyw",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Seated Dumbbell Triceps Extension",
                  Description = "Select the desired weight from the rack and position an adjustable bench at 90 degrees. To get into position, sit in an upright position and lift the dumbbell to the top of your shoulder. Take a deep breath, overlap your hands around the dumbbell, then press it into position overhead. Maintain an overlapping grip and slowly lower the dumbbell behind your head by unlocking your elbows. Once your forearms reach parallel or just below, drive the dumbbell back to the starting point by extending the elbows and flexing the triceps. Repeat for the desired number of repetitions.",
                  EquipmentId = 11, // Dumbbell
                  CategoryId = 2, // Triceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-overhead-dumbbell-tricep-extension_0.jpg",
                  VideoUrl = "https://www.youtube.com/embed/LlCFtWCQc5s",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "One Arm Kettlebell Floor Press",
                  Description = "Begin in a side lying position with the kettlebell next your body. Grasp the handle with both hands and slowly roll onto your back. Once you are laying flat on the floor, bend your knees to roughly 45 degrees and slide your heels towards your butt. Slowly lower the weight until your elbow touches the floor then press to full extension by contracting your triceps and chest. Lower back to the starting position and repeat for the desired number of repetitions.",
                  EquipmentId = 5, // Kettlebells
                  CategoryId = 2, // Triceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/one-arm-kettlebell-floor-press.jpg",
                  VideoUrl = "https://www.youtube.com/embed/fdg6zUZ9YlQ",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Decline Lying Triceps Extension (Skullcrusher)",
                  Description = "Select your desired weight and sit on the edge of an decline bench at roughly 20-30 degrees. To get into position, lay back and keep the bar close to your chest. Once you are supine, press the weight to lockout. Unlock the elbows and allow the ez bar to drop toward your forehead or just above. Once your forearms reach parallel or just below, reverse the movement by extending the elbows while flexing the triceps to lockout the weight. Repeat for the desired number of repetitions.",
                  EquipmentId = 7, // EZ Curl Bar
                  CategoryId = 2, // Triceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/decline-skullcrusher-1.jpg",
                  VideoUrl = "https://www.youtube.com/embed/kVJrVTEt1gE",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },

               // BICEPS
               new Exercise
               {
                  Name = "Incline Dumbbell Curl",
                  Description = "Position an incline bench at roughly 55-65 degrees, select the desired weight from the rack, and sit upright with your back flat against the pad. Using a supinated (palms up) grip, take a deep breath and curl both dumbbells towards your shoulders. Once the biceps are fully shortened, slowly lower the weights back to the starting position. Repeat for the desired number of repetitions.",
                  EquipmentId = 7, // EZ Curl Bar
                  CategoryId = 3, // Biceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/incline-dumbbell-curl-thumb.jpg",
                  VideoUrl = "https://www.youtube.com/embed/UeleXjsE-98",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Biceps Curl Sled Drag",
                  Description = "Load the desired weight onto the sled and attach a set of handles with a nylon strap. Grasp the handles with the arms extended and elbows locked out. Lean away from the sled to establish some resting tension on the strap, then contract the biceps and flex the elbow to drag the sled forward. Walk forward a few steps to reestablish tension and repeat step #3. Repeat until you reach the desired number of repetitions, distance, or time.",
                  EquipmentId = 8, // Cable
                  CategoryId = 3, // Biceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/bicep-curl-sled-drag.jpg",
                  VideoUrl = "https://www.youtube.com/embed/PBs8FX7wH_0",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Standing Dumbbell Drag Curl",
                  Description = "Select the desired weight from the rack and assume a shoulder width stance. Using a supinated (palms up) grip, take a deep breath and curl the dumbbells directly up the front of your body. The elbows will actually drift behind the body as you try to keep the weight as close to your body as possible. Once the biceps are fully shortened, slowly lower the weight back to the starting position. Repeat for the desired number of repetitions.",
                  EquipmentId = 11, // Dumbbell
                  CategoryId = 3, // Biceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/dumbbell-drag-curl.jpg",
                  VideoUrl = "https://www.youtube.com/embed/3ZpEL3xiNhc",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Dumbbell Hammer Preacher Curl",
                  Description = "Select the desired weight from the rack, and sit in an upright position with your chest flat against the preacher bench. Keep your upper arm pressed into the pad and use a neutral (palms facing up) grip. Take a deep breath and slowly lower the dumbbell away from your shoulder. Once the biceps is fully lengthened, curl the weight back to the starting position. Repeat for the desired number of repetitions on both sides.",
                  EquipmentId = 11, // Dumbell
                  CategoryId = 3, // Biceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/preacher-dumbbell-hammer-curl.jpg",
                  VideoUrl = "https://www.youtube.com/embed/ZdcFOgFi1Dg",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },
               new Exercise
               {
                  Name = "Close Grip Standing Barbell Curl",
                  Description = "Select the desired weight, load it onto the bar, and assume a narrower than shoulder width grip. Using a supinated (palms up) grip, take a deep breath and curl the barbell towards your shoulders. Once the biceps are fully shortened, slowly lower the weight back to the starting position. Repeat for the desired number of repetitions.",
                  EquipmentId = 10, // Barbell
                  CategoryId = 3, // Biceps
                  Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                  ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/close-grip-barbell-curl.jpg",
                  VideoUrl = "https://www.youtube.com/embed/exqx_2Uyopw",
                  AddedByUser = dbContext.Users.
                      Where(x => x.UserName == "admin")
                      .FirstOrDefault(),
               },

               // BACK
               new Exercise
                {
                    Name = "Bent Over Kettlebell Row",
                    Description = "Assume a standing position while holding a kettlebell in each hand with a neutral grip. Hinge forward until your torso is roughly parallel with the floor (or slightly above) and then begin the movement by driving the elbows behind the body while retracting the shoulder blades. Pull the kettlebells towards your body until the elbows are at(or just past) the midline and then slowly lower the kettlebells back to the starting position under control. Repeat for the desired number of repetitions.",
                    EquipmentId = 5, // Kettlebells
                    CategoryId = 4, // Back
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/bent-over-kettlebell-row.jpg",
                    VideoUrl = "https://www.youtube.com/embed/RIEwOjk2_Zg",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Quadruped Extension Rotation",
                    Description = "Setup in a quadruped position with your hands directly underneath your shoulders and your knees underneath your hips. Ensure that your toes are tucked underneath and your ankles are flexed. Put one hand on the back of your head, exhale, and rotate your upper back towards the ceiling by leading with the elbow and following with your eyes. Once you run out of range of motion within the upper back, rotate back to the starting position. Repeat for the desired number of repetitions on both sides.",
                    EquipmentId = 1, // Body Only
                    CategoryId = 4, // Back
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/quadruped-extension-rotation.jpg",
                    VideoUrl = "https://www.youtube.com/embed/m97auWvYak8",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Rowing Machine",
                    Description = "Assume a seated position with your feet strapped into the footplates. Take a pronated (double overhand) grip on the bar and sit up upright with the legs and arms extended. Initiate the movement by flexing at the knees and hips while keeping the arms straight. Push your feet into the platform to straighten your legs, lean back slightly, and then proceed to row the handle towards your chest as you exhale to complete the movement. Return to the starting position by lengthening the arms and flexing at the knees and hips. Repeat for the desired time, duration, or distance.",
                    EquipmentId = 9, // Machine
                    CategoryId = 4, // Back
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/concept-2-rowing-machine.jpg",
                    VideoUrl = "https://www.youtube.com/embed/Wy-HuhQXjmI",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Field Goal Angel Foam Rolling",
                    Description = "In a supine position, place a foam roller directly underneath the length of your spine. Position your arms parallel to your torso at right angles and focus on stretching the pecs. While keeping your hands in line with your torso, exhale while extending your arms and reach overhead. Return to the starting position and repeat for the desired number of repetitions.",
                    EquipmentId = 4, // Foam Roll
                    CategoryId = 4, // Back
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/field-goal-angel-foam-rolling.jpg",
                    VideoUrl = "https://www.youtube.com/embed/A-X5TU36bcU",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Tripod Dumbbell Row",
                    Description = "Assume a kneeling position on the bench with your ipsilateral (i.e. same side) hand braced against the bench. Hold a dumbbell in the opposite hand with a neutral grip. Begin the movement by driving the elbow behind the body while retracting the shoulder blade. Pull the dumbbell towards your body until the elbow is at(or just past) the midline and then slowly lower the dumbbells back to the starting position under control. Repeat for the desired number of repetitions on both sides.",
                    EquipmentId = 11, // Dumbbell
                    CategoryId = 4, // Back
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/tripod-dumbbell-row.jpg",
                    VideoUrl = "https://www.youtube.com/embed/78Z2mk9LQoI",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // CHEST
               new Exercise
                {
                    Name = "Incline Dumbbell Bench Press",
                    Description = "Pick up the dumbbells off the floor using a neutral grip (palms facing in). Position the ends of the dumbbells in your hip crease, and sit down on the edge of an incline bench. To get into position, lay back and keep the weights close to your chest. Once you are in position, take a deep breath, and press the dumbbells to lockout at the top. Slowly lower the dumbbells under control as far as comfortably possible (the handles should be about level with your chest). Contract the chest and push the dumbbells back up to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 11, // Dumbbell
                    CategoryId = 5, // Chest
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/incline-dumbbell-bench-press_0.jpg",
                    VideoUrl = "https://www.youtube.com/embed/8nNi8jbbUPE",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Hammer Strength Bench Press",
                    Description = "Sit on the end of the bench and lie back with the handles just below shoulder height. The handles should mimic the position of the bar when benching. Position your palms on the handles, inhale, and set your shoulder blades together on the bench. Press the handles to extension as you exhale but keep the shoulder blades packed. Repeat for the desired number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 5, // Chest
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/machine-bench-press_0.jpg",
                    VideoUrl = "https://www.youtube.com/embed/dMQdd40Y3FQ",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Incline Bench Press",
                    Description = "Lie flat on an incline bench and set your hands just outside of shoulder width. Set your shoulder blades by pinching them together and driving them into the bench. Take a deep breath and allow your spotter to help you with the lift off in order to maintain tightness through your upper back. Let the weight settle and ensure your upper back remains tight after lift off. Inhale and allow the bar to descend slowly by unlocking the elbows. Lower the bar in a straight line to the base of the sternum (breastbone) and touch the chest. Push the bar back up in a straight line by pressing yourself into the bench, driving your feet into the floor for leg drive, and extending the elbows. Repeat for the desired number of repetitions.",
                    EquipmentId = 10, // Barbell
                    CategoryId = 5, // Chest
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/incline-bench-press.jpg",
                    VideoUrl = "https://www.youtube.com/embed/uIzbJX5EVIY",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Standing Cable Fly",
                    Description = "Set both pulleys directly at (or slightly above) shoulder height and select the desired weight. Grasp both handles with a neutral grip and take a step forward to split the stance. Press the handles to lockout while flexing the pecs and extending the elbows. Keep a slight bend in the elbows, move entirely at the shoulder joint, and slowly allow the arms to open while the pecs stretch. Return to the starting position by flexing your pecs and bringing the handles together at chest height. Slowly lower back to the starting position and repeat for the desired number of repetitions.",
                    EquipmentId = 8, // Cable
                    CategoryId = 5, // Chest
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/standing-cable-fly1.jpg",
                    VideoUrl = "https://www.youtube.com/embed/OPYrUGZL8nU",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Chest Dip",
                    Description = "Step up on the dip station (if possible) and position your hands with a neutral grip. Initiate the dip by unlocking the elbows and slowly lowering the body until the forearms are almost parallel with the floor. Control the descent to parallel and then drive back to the starting position by pushing through the palms. Repeat for the desired number of repetitions.",
                    EquipmentId = 1, // Body only
                    CategoryId = 5, // Chest
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/chest-dip.jpg",
                    VideoUrl = "https://www.youtube.com/embed/FG1ENBFsdHU",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // FOREARM
               new Exercise
                {
                    Name = "Seated Barbell Wrist Curl",
                    Description = "Select the desired weight, load it onto the bar, and assume a seated position with the forearms resting comfortably on your thighs. Utilize a supinated (palms up) grip and curl the bar towards your body using just the wrists. Once the forearm flexors are fully shortened, slowly lower the weight back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 10, // Barbell
                    CategoryId = 6, // Forearm
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-barbell-wrist-curl.jpg",
                    VideoUrl = "https://www.youtube.com/embed/cOBaYeX3bYo",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Dumbbell Farmers Carry",
                    Description = "Grasp a dumbbell in each hand using a neutral grip and stand up straight. While maintaining an active shoulder position, hold the dumbbells by your side and walk for a designated distance or amount of time.",
                    EquipmentId = 11, // Dumbbell
                    CategoryId = 6, // Forearm
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/dumbbell-farmers-carry.jpg",
                    VideoUrl = "https://www.youtube.com/embed/j8c9uNjr7nQ",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Forearm Tiger Tail",
                    Description = "While in a seated position, position one end of the tiger tail on a solid surface and hold the other end in one hand. Adjust pressure into forearm by using your bodyweight to bear down on the roller. Slowly roll up and down the length of the forearm for 20 - 30 seconds. Repeat for both the inner and outer portion of the forearm on both sides.",
                    EquipmentId = 1, // Body only
                    CategoryId = 6, // Forearm
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/forearm-tiger-tail.jpg",
                    VideoUrl = "https://www.youtube.com/embed/Lf-w3hoqg4k",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Kettlebell Single Arm Bottoms Up Carry",
                    Description = "Grasp a kettlebell in each hand using a neutral grip and stand up straight. Clean one of the kettlebells to a bottoms up position at shoulder height and hold the other by your side to get into position. While maintaining an active shoulder position, walk for a designated distance or amount of time.",
                    EquipmentId = 5, // Kettlebells
                    CategoryId = 6, // Forearm
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/kettlebell-single-arm-bottoms-up-carry.jpg",
                    VideoUrl = "https://www.youtube.com/embed/zEcZZ1cWafI",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Dumbbell High Low Carry",
                    Description = "Grasp a dumbbell in each hand using a neutral grip and stand up straight. Clean and press one of the dumbbells overhead and hold the other by your side to get into position.While maintaining an active shoulder position, maintain one dumbbell overhead and walk for a designated distance or amount of time.",
                    EquipmentId = 11, // Dumbbell
                    CategoryId = 6, // Forearm
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/dumbbell-high-low-carry.jpg",
                    VideoUrl = "https://www.youtube.com/embed/utpRpR6X2HA",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // TRAPS
               new Exercise
                {
                    Name = "Dumbbell Shrug",
                    Description = "Assume a standing position with the dumbbells on both sides of your body. Hinge forward, inhale, and grab the dumbbells with a neutral grip. Stand up tall and ensure your spine remains neutral. Contract the traps to elevate the shoulders. Squeeze hard at the top and slowly lower the dumbbells back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 11, // Dumbbell
                    CategoryId = 7, // Traps
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/dumbbell-shrug.jpg",
                    VideoUrl = "https://www.youtube.com/embed/dj2Gm628kas",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Barbell Shrug",
                    Description = "Position the safeties just below waist height in a rack. Assume a standing position with the bar in front of your body. Hinge forward, inhale, and grab the bar with a double overhand grip. Stand up tall and ensure your spine remains neutral. Contract the traps to elevate the shoulders. Squeeze hard at the top and slowly lower the bar back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 10, // Barbell
                    CategoryId = 7, // Traps
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/barbell-shrug-1.jpg",
                    VideoUrl = "https://www.youtube.com/embed/6hNudn7Peco",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Machine Shrug",
                    Description = "Assume a standing position in front of the shrug machine. Hinge forward and grasp both handles with a double overhand grip. Assume a standing position, inhale, and contract the traps to elevate the shoulders. Squeeze hard at the top and slowly lower the bar back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 7, // Traps
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/machine-shrug.jpg",
                    VideoUrl = "https://www.youtube.com/embed/1xRJYoiUu-8",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Cable Shrug",
                    Description = "Set 2 cable handles as low as possible and assume a standing position with one handle in each hand. Inhale and contract the traps to elevate the shoulders. Squeeze hard at the top and slowly lower the handles back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 8, // Cable
                    CategoryId = 7, // Traps
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/cable-shrug-1.jpg",
                    VideoUrl = "https://www.youtube.com/embed/LwTq3v2GUF4",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Kettlebell Sumo Deadlift High Pull",
                    Description = "Position the kettlebells between your legs and assume a wider than shoulder width stance (determined by your hip structure and limb length). Push your hips back and hinge forward until your torso is nearly parallel with the floor. Reach down and grasp the handles of the bells with both hands. Inhale, drop your hips, and keep the chest up tall. Drive through the whole foot and focus on pushing the floor away. As the kettlebells nears your hips and your legs lock out, shrug the shoulders and then pull aggressively with the arms.",
                    EquipmentId = 5, // Kettlebells
                    CategoryId = 7, // Traps
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/2-kb-kettlebell-sumo-deadlift-high-pull.jpg",
                    VideoUrl = "https://www.youtube.com/embed/wLm32q4q0ZM",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // ABS
               new Exercise
                {
                    Name = "Weighted Crunch",
                    Description = "Lay supine in a relaxed position with your knees bent. Hold a weight plate directly over your chest and press it to extension. Raise your knees to 90 degrees, at which point they will be perpendicular to the floor. Exhale as you reach towards your toes with the weight plate. Once your abs are fully contracted and your upper back is off the floor, slowly lower yourself back to the starting position. Complete for the assigned number of repetitions.",
                    EquipmentId = 3, // Medicine Ball
                    CategoryId = 8, // Abs
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/weighted-crunch.jpg",
                    VideoUrl = "https://www.youtube.com/embed/6kHg3JAFNFo",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Lying Floor Leg Raise",
                    Description = "Lay supine in a relaxed position with your legs straight and your hands underneath your low back for support. Keep your legs straight and raise them towards your forehead while contracting your abdominals and exhaling. Once your abs are fully contracted and your legs are slightly above parallel, slowly lower your legs back to the starting position. Complete for the assigned number of repetitions.",
                    EquipmentId = 1, // Body only
                    CategoryId = 8, // Abs
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/lying-leg-raise-1.jpg",
                    VideoUrl = "https://www.youtube.com/embed/r24ntO4IvKc",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Exercise Ball Dead Bug",
                    Description = "Setup in a supine position with your legs in a 90/90 position (90 degree bend at the hips and knees) and your arms reaching towards the ceiling while pushing a physioball into your knees. Extend the opposite arm and leg simultaneously as you exhale and press into the physioball with the non working arm and leg to stabilize the ball. Return back to the starting position and repeat on the opposite side. Repeat for the desired number of total repetitions.",
                    EquipmentId = 2, // Exercise Ball
                    CategoryId = 8, // Abs
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/exercise-dead-bug.jpg",
                    VideoUrl = "https://www.youtube.com/embed/VBpNAHGRAFQ",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Pallof Press with Rotation",
                    Description = "Assume a standing position and attach a handle to a cable stack at chest height. Hold the handle to your chest and assume an athletic base position with your feet slightly wider than shoulder width apart. Press the handle horizontally to extension and rotate away from the cable stack slightly. Return to the starting position and repeat for the desired number of repetitions on both sides.",
                    EquipmentId = 8, // Cable
                    CategoryId = 8, // Abs
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/pallof-press-with-rotation.jpg",
                    VideoUrl = "https://www.youtube.com/embed/GW1G_SchrCE",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Bird Dog with Band RNT",
                    Description = "Assume a quadruped position with your knees under hips, hands under shoulders, and toes tucked. Attach a band to the opposite foot and hand. Extend the opposite arm and leg while keeping your hips and torso stable. Slowly lower the arm and leg back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 6, // Bands
                    CategoryId = 8, // Abs
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/bird-dog-with-band-rnt.jpg",
                    VideoUrl = "https://www.youtube.com/embed/9dN9fvGYF28",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // GLUTES
               new Exercise
                {
                    Name = "Banded Good Morning",
                    Description = "Stand on a band with your feet equidistant apart and wrap one end around your neck. Grab the band at roughly shoulder level and pull up slightly to reduce tension on your neck. Begin the movement by unlocking your knees and hinging back into the hips while keeping your spine neutral. Drive through the whole foot as you extend the hip back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 6, // Bands
                    CategoryId = 9, // Glutes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/banded-goodmorning.jpg",
                    VideoUrl = "https://www.youtube.com/embed/WqrheBtIKHI",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Glute Foam Rolling",
                    Description = "In a seated position, place the foam roller directly underneath your glute at the base of your pelvis and lower leg. Cross one leg over the other in a figure four position and shift your weight over the glute of the crossed leg. Drop one hand behind you for support and place the other on the crossed leg. Slowly roll up and down the length of the glute for 20 - 30 seconds. Repeat on the other side.",
                    EquipmentId = 4, // Foam Roll
                    CategoryId = 9, // Glutes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/foam-rolling-glutes.jpg",
                    VideoUrl = "https://www.youtube.com/embed/esUH39n42zw",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Barbell Hip Thrust",
                    Description = "tart in a supine position with your back on a bench and roll a barbell up to the crease of your hips. Drive both feet into the floor and squeeze your glutes while bridging your hips up. Lower your hips back to the starting position and repeat for the desired number of repetitions.",
                    EquipmentId = 10, // Barbell
                    CategoryId = 9, // Glutes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/barbell-hip-thrusts.jpg",
                    VideoUrl = "https://www.youtube.com/embed/lAnqN0J_p5A",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Weighted Hyperextension",
                    Description = "Setup in a hyperextension machine with your feet anchored and torso roughly perpendicular to your legs at a 45 degree angle. Begin in a hinged position, hold a plate to your chest with your arms crossed, and initiate the movement by flexing your glutes. Extend the hips and finish with your body in a straight line. Repeat for the desired number of repetitions.",
                    EquipmentId = 1, // Body only
                    CategoryId = 9, // Glutes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/weighted-hyperextension.jpg",
                    VideoUrl = "https://www.youtube.com/embed/hWfS8WGBboM",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Hyperextension",
                    Description = "Setup in a hyperextension machine with your feet anchored and torso roughly perpendicular to your legs at a 45 degree angle. Begin in a hinged position with your arms crossed and initiate the movement by flexing your glutes. Extend the hips and finish with your body in a straight line. Repeat for the desired number of repetitions.",
                    EquipmentId = 1, // Body only
                    CategoryId = 9, // Glutes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/hyperextensions.jpg",
                    VideoUrl = "https://www.youtube.com/embed/BZMnTSobIAQ",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // QUADRICEPS
               new Exercise
                {
                    Name = "One Leg 45 Degree Leg Press",
                    Description = "Load the machine with the desired weight and take a seat. Sit down and position one foot directly in the middle of the sled. Take a deep breath, extend your leg, and unlock the safeties. Lower the weight under control until the leg is roughly 45 degrees or slightly below. Drive the weight back to the starting position by extending the knee but don’t forcefully lockout. Repeat for the desired number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 10, // Quadricpes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/single-leg-press.jpg",
                    VideoUrl = "https://www.youtube.com/embed/6KTTfLmdwE0",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Kettlebell Push Press",
                    Description = "Set up the kettlebell at chest height in the front rack position. Dip slightly at the knees and then explode straight up as you press the kettlebell overhead. Lower the bell back to the starting position and repeat for the desired number of repetitions on both sides.",
                    EquipmentId = 5, // Kettlebells
                    CategoryId = 10, // Quadricpes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/1-kb-kettlebell-push-press.jpg",
                    VideoUrl = "https://www.youtube.com/embed/2KX2ekrBFoQ",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Wall Ball",
                    Description = "Setup in an athletic base position while holding a medicine ball at your chest with a soft bend in your arms and knees. Squat to parallel by simultaneously bending the hips and knees. Drive upwards to full extension and drive the ball overhead explosively. Catch the med ball as it returns from the wall and repeat steps #2-3 for the desired number of repetitions.",
                    EquipmentId = 3, // Medicine Ball
                    CategoryId = 10, // Quadricpes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/wall-ball.jpg",
                    VideoUrl = "https://www.youtube.com/embed/TS-YN2GkPZw",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Wide Hack Squat",
                    Description = "Load the machine with the desired weight and position your shoulders and back against the pads. Position your feet outside of shoulder width, extend your legs, and release the safety handles. Slowly lower the weight by bending your knees until your thighs are approximately at 90 degrees. Reverse the movement by driving into the platform and extending the knees and hips. Repeat for the desired number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 10, // Quadricpes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/wide-stance-hack-squat.jpg",
                    VideoUrl = "https://www.youtube.com/embed/6GQPsZ1-jYk",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Kettlebell Step Up",
                    Description = "Set up in front of a riser which is 8-12” off the ground. Hold a kettlebell in one hand and initiate the exercise by stepping on to the riser with one leg. Drive through the front foot and extend the knee as you stand up fully. Slowly lower back to the starting position. Repeat for the desired number of repetitions.",
                    EquipmentId = 5, // Kettlebells
                    CategoryId = 10, // Quadricpes
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/1-kb-step-up.jpg",
                    VideoUrl = "https://www.youtube.com/embed/B9A_GONMKYI",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // HAMSTRINGS
               new Exercise
                {
                    Name = "Romanian Deadlift",
                    Description = "Position the bar over the top of your shoelaces and assume a hip width stance. Assume a double overhand grip just outside of hip width and deadlift the weight into position at the top with the hips and knees locked out. Begin the RDL by pushing your hips back and hinging forward until the bar is just below knee height. Drive through the whole foot and focus on pushing the floor away. Return to the starting position and repeat for the desired number of repetitions.",
                    EquipmentId = 10, // Barbell
                    CategoryId = 11, // Hamstrings
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/romanian-deadlift.jpg",
                    VideoUrl = "https://www.youtube.com/embed/-m45n1_x32E",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Seated Leg Curl",
                    Description = "Select the desired weight, then adjust the pad so it rests comfortably above the back of the heels. Tense up the hamstrings by taking the weight slightly off the stack. This is the starting position for the exercise. Take a deep breath, squeeze the hamstrings, and curl the weight up as far as possible while keeping the spine neutral. Slowly lower the weight back to the starting position and repeat for the desired number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 11, // Hamstrings
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-leg-curl-1.jpg",
                    VideoUrl = "https://www.youtube.com/embed/3BWiLFc8Dbg",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Band Assisted Nordic Hamstring Curl",
                    Description = "Loop a band around the upper portion of a lat pull down machine. Set your feet underneath the knee pad and grab onto the band behind your head with both hands. Keeping your hips extended, slowly lower yourself to a parallel position with the floor. Flex your hamstrings and pull yourself back to the starting position while keeping your torso in a straight line. Repeat for the desired number of repetitions.",
                    EquipmentId = 6, // Bands
                    CategoryId = 11, // Hamstrings
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/nordic-hamstring-curl-band-assisted.jpg",
                    VideoUrl = "https://www.youtube.com/embed/SI8bdn_mpqQ",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Exercise Ball Leg Curl",
                    Description = "Setup in a supine position with your feet elevated on a physioball and your arms extended out to the sides. Initiate the movement by flexing your glutes and extending the hips until you have a straight line from your heels through your head. While keeping your hips extended, curl your heels towards your butt by flexing your hamstrings. Slowly lower back to the starting position and repeat for the desired number of repetitions.",
                    EquipmentId = 2, // Exercise Ball
                    CategoryId = 11, // Hamstrings
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/exercise-ball-leg-curl.jpg",
                    VideoUrl = "https://www.youtube.com/embed/OOUtV11bSa8",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Snatch Grip Deadlift",
                    Description = "Position the bar over the top of your shoelaces and assume a hip width stance. Push your hips back and hinge forward until your torso is nearly parallel with the floor. Reach down and grasp the bar using a double overhand snatch grip. Inhale and pull up slightly on the bar while allowing your hips to drop in a seesaw fashion.This phenomenon is commonly referred to as “pulling the slack out of the bar”. As you drop the hips and pull up on the bar, set the lats(imagine you’re trying to squeeze oranges in your armpits) and ensure your armpits are positioned directly over the bar. Drive through the whole foot and focus on pushing the floor away.",
                    EquipmentId = 10, // Barbell
                    CategoryId = 11, // Hamstrings
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/snatch-grip-deadlift.jpg",
                    VideoUrl = "https://www.youtube.com/embed/OCuawmNbo4E",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },

               // CALVES
               new Exercise
                {
                    Name = "Seated Calf Raise",
                    Description = "Take a seat on the machine and place the balls of your feet on the platform with your toes pointed forward - your heels will naturally hang off. Position the base of quads under the knee pad and allow your hands to rest on top. Extend your ankles and release the safety bar. Lower the heels by dorsiflexing the ankles until the calves are fully stretched. Extend the ankles and exhale as you flex the calves. Repeat for the assigned number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 12, // Calves
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/seated-calf-raise-1.jpg",
                    VideoUrl = "https://www.youtube.com/embed/Yh5TXz99xwY",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Standing Machine Calf Raise",
                    Description = "Adjust the shoulder pad corresponding to your height. Step underneath the pad and place the balls of your feet on the platform with your toes pointed straight ahead - your heels will naturally hang off. Extend the hips and knees in order to raise the shoulder pad. Lower the heels by dorsiflexing the ankles until the calves are fully stretched. Extend the ankles and exhale as you flex the calves. Repeat for the assigned number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 12, // Calves
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/standing-machine-calf-raise.jpg",
                    VideoUrl = "https://www.youtube.com/embed/RBslMmWqzzE",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Banded Tibialis Raise",
                    Description = "Attach a band to a kettlebell by threading one end through the loop. Attach the free end to top of your foot and move back slightly to increase tension within the band. Pull your toes toward your face as you flex the anterior portion of your calf. Slowly lower the toes until you feel a stretch in the front of your shin and repeat for the desired number of repetitions.",
                    EquipmentId = 6, // Bands
                    CategoryId = 12, // Calves
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Expert"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/banded-tibialis-raise.jpg",
                    VideoUrl = "https://www.youtube.com/embed/gOV7XZyUv6Y",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Knee Break Ankle Mobilization",
                    Description = "In an upright position, position a plate underneath the upper portion of your foot. Keep your torso erect but bend the knees and allow the ankles to flex as your weight is shifted slightly forward. Once you run out of range of motion in your ankles, extend the knees back to the start position. Repeat for the desired number of repetitions.",
                    EquipmentId = 1, // Body only
                    CategoryId = 12, // Calves
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Beginner"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/knee-break-ankle-mobilization.jpg",
                    VideoUrl = "https://www.youtube.com/embed/KngATp2V7kc",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
               new Exercise
                {
                    Name = "Toes Out Seated Calf Raise",
                    Description = "Take a seat on the machine and place the balls of your feet on the platform with your toes pointed out - your heels will naturally hang off. Position the base of quads under the knee pad and allow your hands to rest on top. Extend your ankles and release the safety bar. Lower the heels by dorsiflexing the ankles until the calves are fully stretched. Extend the ankles and exhale as you flex the calves. Repeat for the assigned number of repetitions.",
                    EquipmentId = 9, // Machine
                    CategoryId = 12, // Calves
                    Difficulty = Enum.Parse<ExerciseDifficulty>("Intermediate"),
                    ImageUrl = "https://cdn.muscleandstrength.com/sites/default/files/toes-out-seated-calf-raise-1.jpg",
                    VideoUrl = "https://www.youtube.com/embed/grb_PSkmVls",
                    AddedByUser = dbContext.Users.
                       Where(x => x.UserName == "admin")
                       .FirstOrDefault(),
                },
            };

            foreach (var item in exercises)
            {
                await dbContext.Exercises.AddAsync(new Exercise
                {
                    Name = item.Name,
                    Description = item.Description,
                    EquipmentId = item.EquipmentId,
                    CategoryId = item.CategoryId,
                    Difficulty = item.Difficulty,
                    ImageUrl = item.ImageUrl,
                    VideoUrl = item.VideoUrl,
                    AddedByUser = item.AddedByUser,
                });
            }
        }
    }
}
