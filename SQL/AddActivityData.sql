select *
from Activity
where tripId=21;

-- Insert activities for Italy Trip (tripId = 21)

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Visit Colosseum', '[3, 5, 13, 16, 23]', '[4, 6, 12, 14, 25, 31]', 'Culture & History', 'Piazza del Colosseo, 1, 00184 Roma RM, Italy', 'Explore the iconic Colosseum in Rome, a symbol of ancient Roman engineering and gladiatorial combat.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Gondola Ride in Venice', '[4, 6, 14, 23, 31, 12]', '[3, 5, 13, 16, 25]', 'Relaxation & Wellness', 'Piazza San Marco, 30124 Venezia VE, Italy', 'Take a romantic gondola ride through the canals of Venice for a unique view of the city’s historical architecture.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Tuscan Wine Tour', '[12, 13, 16, 25, 31]', '[3, 4, 5, 6, 14, 23]', 'Food & Drink', 'Tuscany, Italy', 'Tour the picturesque vineyards of Tuscany and sample some of Italy’s finest wines.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Cooking Class in Florence', '[3, 4, 5, 12, 14, 31]', '[6, 13, 16, 23, 25]', 'Food & Drink', 'Piazza della Signoria, 50122 Firenze FI, Italy', 'Join a hands-on cooking class and learn how to prepare traditional Italian dishes in the heart of Florence.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Pompeii Day Trip', '[4, 5, 6, 16, 23]', '[3, 12, 13, 14, 25, 31]', 'Culture & History', 'Pompei, 80045 Naples, Italy', 'Discover the ancient city of Pompeii, buried by volcanic ash in 79 AD, and explore its remarkably well-preserved ruins.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Lake Como Boat Cruise', '[3, 12, 13, 25, 31]', '[4, 5, 6, 14, 16, 23]', 'Relaxation & Wellness', 'Como, 22100 Como CO, Italy', 'Enjoy a scenic boat ride on Lake Como and soak in breathtaking views of the surrounding mountains and luxury villas.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Cinque Terre Hike', '[3, 5, 6, 14, 23, 31]', '[4, 12, 13, 16, 25]', 'Adventure & Outdoors', 'Cinque Terre, 19018 La Spezia SP, Italy', 'Hike through the stunning Cinque Terre National Park and enjoy panoramic views of colorful cliffside villages and the Ligurian Sea.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Vatican Museum Tour', '[3, 4, 6, 14, 16]', '[5, 12, 13, 23, 25, 31]', 'Culture & History', 'Viale Vaticano, 00120 Città del Vaticano', 'Visit the Vatican Museums to see some of the most famous art collections in the world, including the Sistine Chapel.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Amalfi Coast Scenic Drive', '[5, 12, 13, 16, 25]', '[3, 4, 6, 14, 23, 31]', 'Adventure & Outdoors', 'Amalfi Coast, 84011 Amalfi SA, Italy', 'Take a scenic drive along the dramatic Amalfi Coast, with stunning views of cliffs, colorful towns, and the Mediterranean Sea.');

INSERT INTO Activity
    (tripId, activity, voteYes, voteNo, category, address, details)
VALUES
    (21, 'Truffle Hunting Experience', '[4, 5, 6, 14, 31]', '[3, 12, 13, 16, 23, 25]', 'Food & Drink', 'Piedmont, Italy', 'Embark on a truffle hunt in the Piedmont region, learning from expert hunters and savoring freshly found truffles.');


    INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(166, 'Visit the Colosseum', 'Culture & History', 'Piazza del Colosseo, 1, 00184 Roma RM, Italy', 'Explore the iconic Roman amphitheater and its ancient history.', '[3, 5, 13, 16, 23]', '[4, 6, 12, 14, 25, 31]'),

(166, 'Gondola Ride in Venice', 'Relaxation & Wellness', 'Venice, Italy', 'Enjoy a scenic gondola ride through the canals of Venice.', '[4, 6, 14, 23, 31, 12]', '[3, 5, 13, 16, 25]'),

(166, 'Tuscan Wine Tour', 'Food & Drink', 'Chianti, Tuscany, Italy', 'Taste world-famous wines and enjoy vineyard tours in Tuscany.', '[12, 13, 16, 25, 31]', '[3, 4, 5, 6, 14, 23]'),

(166, 'Florence Cooking Class', 'Food & Drink', 'Florence, Italy', 'Learn to cook authentic Italian dishes with local chefs.', '[3, 4, 5, 12, 14, 31]', '[6, 13, 16, 23, 25]'),

(166, 'Pompeii Day Trip', 'Culture & History', 'Pompeii, Metropolitan City of Naples, Italy', 'Walk through the ruins of the ancient Roman city.', '[4, 5, 6, 16, 23]', '[3, 12, 13, 14, 25, 31]'),

(166, 'Lake Como Boat Cruise', 'Relaxation & Wellness', 'Lake Como, Italy', 'Cruise on the stunning Lake Como surrounded by mountains.', '[3, 12, 13, 25, 31]', '[4, 5, 6, 14, 16, 23]'),

(166, 'Cinque Terre Hike', 'Adventure & Outdoors', 'Cinque Terre, Liguria, Italy', 'Hike between colorful coastal villages with sea views.', '[3, 5, 6, 14, 23, 31]', '[4, 12, 13, 16, 25]'),

(166, 'Vatican Museum Tour', 'Culture & History', 'Viale Vaticano, 00165 Roma RM, Italy', 'See Michelangelo’s Sistine Chapel and Vatican treasures.', '[3, 4, 6, 14, 16]', '[5, 12, 13, 23, 25, 31]'),

(166, 'Amalfi Coast Drive', 'Adventure & Outdoors', 'Amalfi Coast, Italy', 'Take a scenic drive along the dramatic Amalfi coastline.', '[5, 12, 13, 16, 25]', '[3, 4, 6, 14, 23, 31]'),

(166, 'Truffle Hunting in Umbria', 'Adventure & Outdoors', 'Umbria, Italy', 'Join a local expert to find and taste Italian truffles.', '[4, 5, 6, 14, 31]', '[3, 12, 13, 16, 23, 25]');

--japan---

INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(167, 'Mount Fuji Hike', 'Adventure & Outdoors', 'Mount Fuji, Honshu, Japan', 'Climb or view the iconic Mount Fuji with scenic vistas.', '[3, 5, 6]', '[8, 10, 12]'),

(167, 'Tokyo Sushi Making Class', 'Food & Drink', 'Shinjuku, Tokyo, Japan', 'Learn to make traditional sushi from expert chefs in Tokyo.', '[6, 10, 12]', '[3, 5, 8]'),

(167, 'Kyoto Temple Tour', 'Culture & History', 'Kyoto, Japan', 'Visit historic temples including Kinkaku-ji and Fushimi Inari-taisha.', '[3, 8, 10, 12]', '[5, 6]'),

(167, 'Onsen Spa Day in Hakone', 'Relaxation & Wellness', 'Hakone, Kanagawa, Japan', 'Relax in natural hot springs with views of mountains.', '[5, 6, 12]', '[3, 8, 10]'),

(167, 'Osaka Dotonbori Night Walk', 'Entertainment & Nightlife', 'Dotonbori, Osaka, Japan', 'Explore vibrant nightlife, food stalls, and neon lights in Osaka.', '[3, 5, 8, 10]', '[6, 12]'),

(167, 'Tea Ceremony Experience', 'Culture & History', 'Uji, Kyoto, Japan', 'Participate in a traditional Japanese tea ceremony with a tea master.', '[5, 6, 8, 10]', '[3, 12]'),

(167, 'Snow Monkey Park Visit', 'Adventure & Outdoors', 'Jigokudani Monkey Park, Nagano, Japan', 'See wild monkeys bathing in hot springs in snowy mountains.', '[3, 6, 10]', '[5, 8, 12]'),

(167, 'Nara Deer Park Walk', 'Adventure & Outdoors', 'Nara, Japan', 'Feed and walk among tame deer in the historical city of Nara.', '[3, 5, 12]', '[6, 8, 10]'),

(167, 'Sapporo Ramen Street Tour', 'Food & Drink', 'Sapporo, Hokkaido, Japan', 'Taste multiple regional ramen styles along this famous street.', '[6, 8, 10]', '[3, 5, 12]'),

(167, 'Ghibli Museum Visit', 'Entertainment & Nightlife', 'Mitaka, Tokyo, Japan', 'Explore the whimsical worlds of Studio Ghibli with interactive exhibits.', '[3, 6, 12]', '[5, 8, 10]');

-- iceland

INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(168, 'Golden Circle Tour', 'Culture & History', 'Þingvellir, Gullfoss & Geysir, Iceland', 'See Iceland’s most famous sights including waterfalls, geysers, and historic sites.', '[5, 6, 14]', '[3, 7, 8]'),

(168, 'Blue Lagoon Spa', 'Relaxation & Wellness', 'Blue Lagoon, Grindavík, Iceland', 'Soak in geothermal mineral waters surrounded by volcanic landscape.', '[3, 6, 8]', '[5, 7, 14]'),

(168, 'Northern Lights Hunt', 'Adventure & Outdoors', 'Reykjavík Departure, Iceland', 'Night excursion to see the Aurora Borealis under optimal conditions.', '[5, 7, 14]', '[3, 6, 8]'),

(168, 'Icelandic Horseback Riding', 'Adventure & Outdoors', 'Mosfellsbær, Iceland', 'Ride a unique Icelandic horse through scenic countryside.', '[3, 6, 7]', '[5, 8, 14]'),

(168, 'Lava Caving Tour', 'Adventure & Outdoors', 'Raufarhólshellir, Iceland', 'Explore ancient lava tunnels formed by volcanic eruptions.', '[5, 6, 8]', '[3, 7, 14]'),

(168, 'Reykjavík Food Walk', 'Food & Drink', 'Downtown Reykjavík, Iceland', 'Taste authentic Icelandic dishes including lamb, seafood, and Skyr.', '[3, 5, 8]', '[6, 7, 14]'),

(168, 'Whale Watching from Húsavík', 'Adventure & Outdoors', 'Húsavík, Iceland', 'Take a boat tour to spot humpback whales and other marine life.', '[6, 7, 14]', '[3, 5, 8]'),

(168, 'Soak in Myvatn Nature Baths', 'Relaxation & Wellness', 'Mývatn, North Iceland', 'Relax in geothermally heated pools with scenic lake views.', '[5, 8, 14]', '[3, 6, 7]'),

(168, 'Arctic Circle Flight Tour', 'Adventure & Outdoors', 'Akureyri Airport, Iceland', 'Take a scenic flight across the Arctic Circle and glacial landscapes.', '[3, 6, 14]', '[5, 7, 8]'),

(168, 'Viking History Museum Visit', 'Culture & History', 'The Settlement Exhibition, Reykjavík, Iceland', 'Learn about Iceland’s Viking roots through archaeological exhibits.', '[3, 5, 7]', '[6, 8, 14]');

-- thailand--
INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(169, 'Explore the Grand Palace', 'Culture & History', 'Na Phra Lan Rd, Bangkok, Thailand', 'Visit Thailand’s most famous landmark, full of intricate architecture and history.', '[3, 4, 6, 9]', '[5, 7, 8, 25]'),

(169, 'Thai Cooking Class in Chiang Mai', 'Food & Drink', 'Old City, Chiang Mai, Thailand', 'Learn to cook authentic Thai dishes like Pad Thai and green curry.', '[5, 6, 7, 8]', '[3, 4, 9, 25]'),

(169, 'Island Hopping in Krabi', 'Adventure & Outdoors', 'Ao Nang Pier, Krabi, Thailand', 'Boat tour exploring stunning limestone islands and hidden beaches.', '[3, 5, 9, 25]', '[4, 6, 7, 8]'),

(169, 'Elephant Sanctuary Visit', 'Adventure & Outdoors', 'Mae Wang, Chiang Mai, Thailand', 'Ethical experience interacting with rescued elephants in natural habitat.', '[4, 5, 6, 8]', '[3, 7, 9, 25]'),

(169, 'Relax at Phi Phi Islands', 'Relaxation & Wellness', 'Ko Phi Phi Leh, Thailand', 'Spend the day relaxing, swimming, and snorkeling on white sandy beaches.', '[3, 6, 7, 9]', '[4, 5, 8, 25]'),

(169, 'Full Moon Party in Koh Phangan', 'Entertainment & Nightlife', 'Haad Rin Beach, Koh Phangan, Thailand', 'Experience the famous beach party with music, dancing, and neon lights.', '[5, 6, 7, 8]', '[3, 4, 9, 25]'),

(169, 'Floating Market Tour', 'Culture & History', 'Damnoen Saduak, Ratchaburi, Thailand', 'Explore bustling canals filled with food and handmade goods.', '[3, 4, 6, 25]', '[5, 7, 8, 9]'),

(169, 'Thai Massage and Spa Day', 'Relaxation & Wellness', 'Sukhumvit Rd, Bangkok, Thailand', 'Unwind with traditional Thai massage and herbal treatments.', '[3, 5, 8, 9]', '[4, 6, 7, 25]'),

(169, 'Bangkok Rooftop Bar Crawl', 'Entertainment & Nightlife', 'Sathorn & Silom Districts, Bangkok, Thailand', 'Enjoy city views and cocktails across Bangkok’s best rooftop bars.', '[4, 6, 7, 9]', '[3, 5, 8, 25]'),

(169, 'Wat Pho Temple & Reclining Buddha', 'Culture & History', 'Sanam Chai Rd, Bangkok, Thailand', 'Visit the temple housing the giant reclining Buddha and learn about Thai Buddhism.', '[3, 5, 6, 25]', '[4, 7, 8, 9]');

--spain
INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(172, 'Alhambra Palace Tour', 'Culture & History', 'Calle Real de la Alhambra, Granada, Spain', 'Explore the Moorish fortress-palace with a guided historical tour.', '[5, 6, 9]', '[7, 44]'),

(172, 'Flamenco Night in Seville', 'Entertainment & Nightlife', 'Barrio Santa Cruz, Seville, Spain', 'Enjoy an authentic Flamenco performance with tapas and sangria.', '[7, 6, 44]', '[5, 9]'),

(172, 'Hike in Sierra Nevada Mountains', 'Adventure & Outdoors', 'Sierra Nevada, Granada, Spain', 'A guided hiking trip through Andalusia’s stunning highlands.', '[5, 6, 7]', '[9, 44]'),

(172, 'Tapas Tasting Tour in Málaga', 'Food & Drink', 'Old Town, Málaga, Spain', 'Sample local tapas and wine on a guided walking tour.', '[6, 9, 44]', '[5, 7]'),

(172, 'Relax at Costa del Sol Beach', 'Relaxation & Wellness', 'Playa de la Malagueta, Málaga, Spain', 'Spend a relaxing day at the sunny beach with optional spa services.', '[5, 7, 44]', '[6, 9]'),

(172, 'Cordoba Mezquita Visit', 'Culture & History', 'Calle Cardenal Herrero, Córdoba, Spain', 'Tour the famous mosque-cathedral blending Islamic and Christian architecture.', '[6, 9, 44]', '[5, 7]'),

(172, 'Wine Tasting in Ronda', 'Food & Drink', 'Ronda Vineyards, Málaga, Spain', 'Taste regional wines at a scenic Andalusian vineyard.', '[5, 6, 44]', '[7, 9]'),

(172, 'Sunset Rooftop Dinner in Seville', 'Entertainment & Nightlife', 'Centro, Seville, Spain', 'Dinner with panoramic views of Seville’s skyline at sunset.', '[7, 9, 44]', '[5, 6]'),

(172, 'Horseback Riding in Doñana Park', 'Adventure & Outdoors', 'Doñana National Park, Huelva, Spain', 'Explore wetlands and forests on horseback in one of Spain’s national treasures.', '[5, 6, 9]', '[7, 44]'),

(172, 'Arabian Baths Experience', 'Relaxation & Wellness', 'Baños Árabes, Córdoba, Spain', 'Enjoy traditional hot baths, steam rooms, and massages in a restored hammam.', '[6, 7, 9]', '[5, 44]');


INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(176, 'Goat Yoga on a Rooftop', 'Relaxation & Wellness', '123 Goatway Blvd, Portland, OR', 'Do yoga with goats that may or may not climb on you.', '[6, 9, 3]', '[5, 7, 12]'),

(176, 'Tour the Peculiarium', 'Culture & History', '2234 NW Thurman St, Portland, OR', 'A museum full of the strange, the bizarre, and a life-size Bigfoot.', '[5, 6, 12]', '[3, 7, 9]'),

(176, 'Mushroom Latte Crawl', 'Food & Drink', 'Various Cafés, Portland, OR', 'Sample mushroom-based coffee until you hallucinate responsibility.', '[3, 5, 7]', '[6, 9, 12]'),

(176, 'Watch the Unipiper Perform', 'Entertainment & Nightlife', 'Downtown Portland, OR', 'Bagpipes. Unicycle. Darth Vader mask. Just Portland things.', '[6, 7, 12]', '[3, 5, 9]'),

(176, 'Witchy Aura Photo Booth', 'Culture & History', '319 NE Wygant St, Portland, OR', 'See your aura, buy a crystal, and maybe unlock your third eye.', '[3, 6, 9]', '[5, 7, 12]'),

(176, 'Tiny House Hotel Sleepover', 'Relaxation & Wellness', '5009 NE 11th Ave, Portland, OR', 'Sleep in a house the size of your luggage and love it.', '[5, 6, 9]', '[3, 7, 12]'),

(176, 'DIY Taxidermy Class', 'Adventure & Outdoors', '13 Oddity Ln, Portland, OR', 'Stuff a squirrel and question your life choices.', '[3, 6, 12]', '[5, 7, 9]'),

(176, 'Soapbox Derby Mayhem', 'Adventure & Outdoors', 'Mt. Tabor Park, Portland, OR', 'Watch grown adults crash glorified carts with pride.', '[5, 6, 7]', '[3, 9, 12]'),

(176, 'Psychic Chicken Reading', 'Entertainment & Nightlife', '432 Cluck St, Portland, OR', 'Ask life questions. Chicken pecks at tarot cards. Fate sealed.', '[6, 9, 12]', '[3, 5, 7]'),

(176, 'Midnight Donut Crawl', 'Food & Drink', 'Multiple Voodoo Donut Locations, Portland, OR', 'Donuts, glitter, and sugar-induced epiphanies after dark.', '[3, 5, 9]', '[6, 7, 12]');

select * from trip
--- puerto rico --
INSERT INTO Activity (TripId, Activity, Category, Address, Details, VoteYes, VoteNo)
VALUES
(173, 'Bioluminescent Bay Kayaking', 'Adventure & Outdoors', 'Laguna Grande, Fajardo, PR', 'Kayak at night through glowing waters filled with bioluminescent plankton.', '[3]', '[]'),

(173, 'Salsa Dancing in Old San Juan', 'Entertainment & Nightlife', 'Calle del Cristo, San Juan, PR', 'Learn spicy dance moves under the stars with local instructors.', '[]', '[3]'),

(173, 'Coffee Plantation Tour', 'Food & Drink', 'Hacienda Pomarrosa, Ponce, PR', 'Sip fresh Puerto Rican coffee straight from the source.', '[3]', '[]'),

(173, 'El Yunque Rainforest Hike', 'Adventure & Outdoors', 'El Yunque National Forest, PR', 'Hike through lush tropical trails and waterfall swim spots.', '[]', '[3]'),

(173, 'Historic Fort Tour', 'Culture & History', 'Castillo San Felipe del Morro, San Juan, PR', 'Walk the ramparts of a centuries-old Spanish fortress.', '[3]', '[]'),

(173, 'Beach Hammock & Piña Coladas', 'Relaxation & Wellness', 'Flamenco Beach, Culebra, PR', 'Swing in a hammock with a cold drink and zero regrets.', '[3]', '[]'),

(173, 'Street Art & Mofongo Crawl', 'Culture & History', 'Santurce, San Juan, PR', 'See murals and taste mofongo at hole-in-the-wall gems.', '[]', '[3]'),

(173, 'Island Hopping by Catamaran', 'Adventure & Outdoors', 'Fajardo Marina, PR', 'Jump between tropical islands with snacks and snorkeling gear.', '[3]', '[]'),

(173, 'Sunset Drum Circle', 'Entertainment & Nightlife', 'Ocean Park Beach, San Juan, PR', 'Join a beach drum jam at golden hour—no rhythm required.', '[]', '[3]'),

(173, 'Spa Day in the Mountains', 'Relaxation & Wellness', 'Orocovis, PR', 'Steam, soak, and sigh in the lush Puerto Rican highlands.', '[3]', '[]');

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