﻿namespace MyFitnessApp.Common
{
    public static class DataConstants
    {
        // ApplicationUser Model
        public const int ApplicationUserUserNameMinLength = 2;
        public const int ApplicationUserUserNameMaxLength = 20;

        public const int ApplicationUserFirstNameMinLength = 2;
        public const int ApplicationUserFirstNameMaxLength = 20;

        public const int ApplicationUserLastNameMinLength = 2;
        public const int ApplicationUserLastNameMaxLength = 20;

        // Article Model
        public const int ArticleTitleMMinLength = 2;
        public const int ArticleTitleMaxLength = 100;

        public const int ArticleContentMinLength = 2;
        public const int ArticleContentMaxLength = 10000;

        // ArticleCategory Model
        public const int ArticleCategoryTitleMinLength = 2;
        public const int ArticleCategoryTitleMaxLength = 20;

        // Comment Model
        public const int CommentContentMaxLength = 5000;

        // Post Model
        public const int PostContentMaxLength = 5000;

        // Exercise Model
        public const int ExerciseNameMinLength = 2;
        public const int ExerciseNameMaxLength = 50;

        public const int ExerciseDescriptionMinLength = 2;
        public const int ExerciseDescriptionMaxLength = 5000;

        public const int ExerciseRepetitionsMinValue = 1;
        public const int ExerciseRepetitionsMaxValue = 100;

        public const int ExerciseSetsMinValue = 1;
        public const int ExerciseSetsMaxValue = 100;

        public const double ExerciseWeightMinValue = 0;
        public const double ExerciseWeightMaxValue = 500;

        public const double ExerciseDurationInMinutesMinValue = 1;
        public const double ExerciseDurationInMinutesMaxValue = 200;

        public const double ExerciseCaloriesBurnedMinValue = 0;
        public const double ExerciseCaloriesBurnedMaxValue = 5000;

        // ExerciseCategory Model
        public const int ExerciseCategoryNameMinLength = 2;
        public const int ExerciseCategoryNameMaxLength = 20;

        // ExerciseEquipment Model
        public const int ExerciseEquipmentNameMinLength = 2;
        public const int ExerciseEquipmentNameMaxLength = 20;

        // Food Model
        public const int FoodNameMinLength = 2;
        public const int FoodNameMaxLength = 20;

        public const int FoodBrandNameMinLength = 2;
        public const int FoodBrandNameMaxLength = 20;

        public const int FoodNutritionMinValue = 0;
        public const int FoodNutritionMaxValue = 20000;

        public const int FoodNutritionInPercentsMinValue = 0;
        public const int FoodNutritionInPercentsMaxValue = 100;

        public const int FoodQuantityInGramsMinValue = 1;
        public const int FoodQuantityInGramsMaxValue = 5000;

        // Profile Model
        public const double ProfileWeightInKgMinValue = 20;
        public const double ProfileWeightInKgMaxValue = 400;

        public const double ProfileBodyMeasurementMinValue = 1;
        public const double ProfileBodyMeasurementMaxValue = 500;

        public const int ProfileDailyIntakeGoalMinValue = 1;
        public const int ProfileDailyIntakeGoalMaxValue = 10000;
    }
}