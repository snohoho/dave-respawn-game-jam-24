using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Voice Line Catalog", fileName = "Voice Line Catalog")]
public class VoiceLineCatalog : ScriptableObject
{
    public enum VoiceLineName
    {
        TestAudio = 0,
        TestAudio2 = 1,
        Game_Start = 3,
        Left_outside_apartment = 4,
        Turn_right_outside_home = 5,
        Falling_into_sotheastern_manhole = 6,
        Southern_sewer_fork = 7,
        Second_alley_sewer_entrance = 2,
        Walking_down_northeastern_road = 8,
        Northeasternmost_manhole = 9,
        Approaching_final_destination = 10,
        Trust_ending = 11,
        First_alley = 12,
        Second_alley = 13,
        South_of_first_elevator = 14,
        Roof_construction_arrival = 15,
        Construction_platforming = 16,
        Diverting_paths_on_rooftop = 17,
        Balcony_bridge = 18,
        Balcony_ending = 19,
        McDonalds_spotted = 20,
        McDonalds_ending = 21,
        Middle_road = 22,
        Four_way_sewer_intersection = 23,
        Water_tunnel_arrival = 24,
        Bad_ending = 25,
        Sewer_entrance_near_building_with_first_elevator = 26,
        Turning_around_going_home = 27,
        Arriving_home = 28,
        Kinda_fed_up = 29,
        Completely_fed_up = 30

    }

    [SerializeField] private AudioClip[] AudioClips;

    public AudioClip GetAudioClip(VoiceLineName voiceLine) => AudioClips[(int)voiceLine];
}
