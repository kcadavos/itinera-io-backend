Select * from Activity WHERE tripid=30;

select * from dbo.[User];


INSERT INTO Activity (tripId, activity, category, address, details, voteYes, voteNo)
VALUES
(1, 'Cloud 9 Surfing', 'Adventure & Outdoors', 'Cloud 9, General Luna', 'Ride the legendary Cloud 9 wave, perfect for experienced surfers', '[1,2,3]', '[]'),
(1, 'Surf Lessons', 'Adventure & Outdoors', 'Jacking Horse Beach, General Luna', 'Beginner-friendly surf lessons with experienced local instructors', '[2,3]', '[]'),
(1, 'Island Hopping Tour', 'Adventure & Outdoors', 'General Luna Port', 'Visit Naked Island, Daku Island, and Guyam Island with lunch included', '[1,2,3]', '[]'),
(1, 'Sugba Lagoon Trip', 'Adventure & Outdoors', 'Del Carmen', 'Paddle board or kayak in the emerald waters of Sugba Lagoon', '[1,2]', '[]'),
(1, 'Magpupungko Rock Pools', 'Adventure & Outdoors', 'Pilar Municipality', 'Explore natural tide pools during low tide with cliff jumping opportunities', '[1,2]', '[]'),
(1, 'Siargao Boulevard Sunset Walk', 'Relaxation & Wellness', 'Tourism Road, General Luna', 'Enjoy the stunning sunset views along the newly built boardwalk', '[1,2]', '[]'),
(1, 'Dinner at Kermit', 'Food & Drink', 'Tourism Road, General Luna', 'Enjoy wood-fired pizza and Filipino-Italian fusion at this popular restaurant', '[1,2]', '[]'),
(1, 'Coconut Grove Picnic', 'Relaxation & Wellness', 'Palm Tree Highway', 'Relax under palm trees with a picnic lunch while admiring the coconut groves', '[1,2]', '[]'),
(1, 'Sohoton Cove National Park', 'Adventure & Outdoors', 'Bucas Grande Island', 'Day trip to see jellyfish sanctuary and hidden lagoons in nearby Bucas Grande', '[]', '[]'),
(1, 'Taktak Falls Visit', 'Adventure & Outdoors', 'Santa Monica', 'Trek to the island''s most scenic waterfall for swimming and photos', '[1,2]', '[]'),
(1, 'Pacifico Beach Day', 'Relaxation & Wellness', 'Pacifico, North Siargao', 'Escape the crowds and enjoy the peaceful beaches on the northern coast', '[1,2]', '[]'),
(1, 'Siargao Night Market', 'Culture & History', 'Tourism Road, General Luna', 'Browse local crafts and taste street food at the evening market', '[1,2,3]', '[]'),
(1, 'Jungle Disco Party', 'Entertainment & Nightlife', 'Viento Del Mar, General Luna', 'Experience Siargao''s famous beach party with live DJs and dancing', '[1,2,3]', '[]'),
(1, 'Tayangban Cave Pool', 'Adventure & Outdoors', 'Pilar Municipality', 'Swim through a cave system that opens into a natural pool', '[1,2,3]', '[]'),
(1, 'Seafood Dinner at Harana', 'Food & Drink', 'Tourism Road, General Luna', 'Fresh-caught seafood prepared with local flavors at beachfront restaurant', '[1,2,3]', '[]');

select * from Activity where TripId=1

select * from Trip where Id=21;

update trip set isVotingOpen=1 where Id=21

Select * from dbo.[User];




INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(183, 'Bioluminescent Bay Kayaking', 'Adventure & Outdoors', 'Laguna Grande, Fajardo, PR', 'Kayak at night through glowing waters filled with bioluminescent plankton.', '[3]', '[7]'),

(183, 'Salsa Dancing in Old San Juan', 'Entertainment & Nightlife', 'Calle del Cristo, San Juan, PR', 'Learn spicy dance moves under the stars with local instructors.', '[7]', '[3]'),

(183, 'Coffee Plantation Tour', 'Food & Drink', 'Hacienda Pomarrosa, Ponce, PR', 'Sip fresh Puerto Rican coffee straight from the source.', '[3, 7]', '[]'),

(183, 'El Yunque Rainforest Hike', 'Adventure & Outdoors', 'El Yunque National Forest, PR', 'Hike through lush tropical trails and waterfall swim spots.', '[3]', '[7]'),

(183, 'Historic Fort Tour', 'Culture & History', 'Castillo San Felipe del Morro, San Juan, PR', 'Walk the ramparts of a centuries-old Spanish fortress.', '[7]', '[3]'),

(183, 'Beach Hammock & Piña Coladas', 'Relaxation & Wellness', 'Flamenco Beach, Culebra, PR', 'Swing in a hammock with a cold drink and zero regrets.', '[3, 7]', '[]'),

(183, 'Street Art & Mofongo Crawl', 'Culture & History', 'Santurce, San Juan, PR', 'See murals and taste mofongo at hole-in-the-wall gems.', '[3]', '[7]'),

(183, 'Island Hopping by Catamaran', 'Adventure & Outdoors', 'Fajardo Marina, PR', 'Jump between tropical islands with snacks and snorkeling gear.', '[7]', '[3]'),

(183, 'Sunset Drum Circle', 'Entertainment & Nightlife', 'Ocean Park Beach, San Juan, PR', 'Join a beach drum jam at golden hour—no rhythm required.', '[3]', '[7]'),

(183, 'Spa Day in the Mountains', 'Relaxation & Wellness', 'Orocovis, PR', 'Steam, soak, and sigh in the lush Puerto Rican highlands.', '[7]', '[3]');