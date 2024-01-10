module Places

open App

// These data are from ChatGPT for cities provided by Harry dataset
// They are mostly used just for PoC so we have more data to operate on UI (aggregate, filter)

let data: City list =
    [
        {
            Name = "Shenzhen"
            Country = "China"
            Population = 17.56<milion>
            Location = 114.0579, 22.5431
        }
        {
            Name = "Kinshasa"
            Country = "Democratic Republic of the Congo"
            Population = 15.0<milion>
            Location = 15.2663, -4.4419
        }
        {
            Name = "Lima"
            Country = "Peru"
            Population = 9.75<milion>
            Location = -77.0428, -12.0464
        }
        {
            Name = "Tianjin"
            Country = "China"
            Population = 13.58<milion>
            Location = 117.3616, 39.3434
        }
        {
            Name = "Muscat"
            Country = "Oman"
            Population = 1.4<milion>
            Location = 58.3829, 23.5880
        }
        {
            Name = "Beijing"
            Country = "China"
            Population = 21.54<milion>
            Location = 116.4074, 39.9042
        }
        {
            Name = "Melbourne"
            Country = "Australia"
            Population = 5.07<milion>
            Location = 144.9631, -37.8136
        }
        {
            Name = "Chongqing"
            Country = "China"
            Population = 15.87<milion>
            Location = 106.5040, 29.5630
        }
        {
            Name = "Nairobi"
            Country = "Kenya"
            Population = 4.7<milion>
            Location = 36.8219, -1.2921
        }
        {
            Name = "Ho Chi Minh City"
            Country = "Vietnam"
            Population = 8.4<milion>
            Location = 106.6297, 10.8231
        }

        {
            Name = "Lagos"
            Country = "Nigeria"
            Population = 14.3<milion>
            Location = 3.3792, 6.5244
        }
        {
            Name = "Tokyo"
            Country = "Japan"
            Population = 37.4<milion>
            Location = 139.6917, 35.6895
        }
        {
            Name = "Hangzhou"
            Country = "China"
            Population = 10.36<milion>
            Location = 120.1551, 30.2741
        }
        {
            Name = "Foshan"
            Country = "China"
            Population = 7.9<milion>
            Location = 113.1227, 23.0288
        }
        {
            Name = "Manila"
            Country = "Philippines"
            Population = 13.9<milion>
            Location = 120.9822, 14.5995
        }
        {
            Name = "Seoul"
            Country = "South Korea"
            Population = 9.7<milion>
            Location = 126.9780, 37.5665
        }
        {
            Name = "Bangkok"
            Country = "Thailand"
            Population = 10.54<milion>
            Location = 100.5018, 13.7563
        }
        {
            Name = "Osaka"
            Country = "Japan"
            Population = 19.22<milion>
            Location = 135.5022, 34.6937
        }
        {
            Name = "Tehran"
            Country = "Iran"
            Population = 8.7<milion>
            Location = 51.3890, 35.6892
        }
        {
            Name = "Lahore"
            Country = "Pakistan"
            Population = 11.13<milion>
            Location = 74.3587, 31.5204
        }
        {
            Name = "Los Angeles"
            Country = "United States"
            Population = 3.99<milion>
            Location = -118.2437, 34.0522
        }
        {
            Name = "London"
            Country = "United Kingdom"
            Population = 8.98<milion>
            Location = -0.1276, 51.5072
        }
        {
            Name = "Dongguan"
            Country = "China"
            Population = 8.22<milion>
            Location = 113.7518, 23.0207
        }
        {
            Name = "Hyderabad"
            Country = "India"
            Population = 10.0<milion>
            Location = 78.4867, 17.3850
        }
        {
            Name = "Panama Canal"
            Country = "Panama"
            Population = 1.5<milion>
            Location = -79.5167, 8.9833
        }
        {
            Name = "Bangalore"
            Country = "India"
            Population = 12.34<milion>
            Location = 77.5946, 12.9716
        }
        {
            Name = "Cologne"
            Country = "Germany"
            Population = 1.08<milion>
            Location = 6.9603, 50.9375
        }
        {
            Name = "Taipei"
            Country = "Taiwan"
            Population = 2.65<milion>
            Location = 121.5654, 25.0330
        }
        {
            Name = "Mexico City"
            Country = "Mexico"
            Population = 21.78<milion>
            Location = -99.1332, 19.4326
        }
        {
            Name = "Panama"
            Country = "Panama"
            Population = 1.5<milion>
            Location = -79.5167, 8.9833
        }
        {
            Name = "Buenos Aires"
            Country = "Argentina"
            Population = 15.15<milion>
            Location = -58.3816, -34.6037
        }
        {
            Name = "Istanbul"
            Country = "Turkey"
            Population = 15.52<milion>
            Location = 28.9784, 41.0082
        }
        {
            Name = "Chongqing"
            Country = "China"
            Population = 15.87<milion>
            Location = 106.5040, 29.5630
        }
        {
            Name = "Paranagua"
            Country = "Brazil"
            Population = 0.15<milion>
            Location = -48.5093, -25.5204
        }
        {
            Name = "Tongshan"
            Country = "China"
            Population = 1.35<milion>
            Location = 117.1848, 34.2610
        }
        {
            Name = "Shanghai"
            Country = "China"
            Population = 26.32<milion>
            Location = 121.4737, 31.2304
        }
        {
            Name = "Sao Paulo"
            Country = "Brazil"
            Population = 22.0<milion>
            Location = -46.6333, -23.5505
        }
        {
            Name = "Kolkata"
            Country = "India"
            Population = 14.85<milion>
            Location = 88.3639, 22.5726
        }
        {
            Name = "Moscow"
            Country = "Russia"
            Population = 12.5<milion>
            Location = 37.6173, 55.7558
        }
        {
            Name = "Karachi"
            Country = "Pakistan"
            Population = 16.1<milion>
            Location = 67.0099, 24.8615
        }


        {
            Name = "Chennai"
            Country = "India"
            Population = 10.9<milion>
            Location = 80.2707, 13.0827
        }
        {
            Name = "Xi'an"
            Country = "China"
            Population = 12.0<milion>
            Location = 108.9398, 34.3416
        }
        {
            Name = "Luanda"
            Country = "Angola"
            Population = 8.3<milion>
            Location = 13.2344, -8.8147
        }
        {
            Name = "Zhoukou"
            Country = "China"
            Population = 8.5<milion>
            Location = 114.6418, 33.6204
        }
        {
            Name = "Ganzhou"
            Country = "China"
            Population = 8.6<milion>
            Location = 114.9350, 25.8318
        }
        {
            Name = "Kuala Lumpur"
            Country = "Malaysia"
            Population = 7.2<milion>
            Location = 101.6869, 3.1390
        }
        {
            Name = "Heze"
            Country = "China"
            Population = 8.7<milion>
            Location = 115.4807, 35.2338
        }
        {
            Name = "Quanzhou"
            Country = "China"
            Population = 8.2<milion>
            Location = 118.6757, 24.8741
        }
        {
            Name = "Chicago"
            Country = "United States"
            Population = 2.71<milion>
            Location = -87.6298, 41.8781
        }
        {
            Name = "Nanjing"
            Country = "China"
            Population = 8.5<milion>
            Location = 118.7969, 32.0603
        }

        {
            Name = "Jining"
            Country = "China"
            Population = 8.1<milion>
            Location = 116.5871, 35.4149
        }
        {
            Name = "Hanoi"
            Country = "Vietnam"
            Population = 7.8<milion>
            Location = 105.8342, 21.0278
        }
        {
            Name = "Pune"
            Country = "India"
            Population = 6.4<milion>
            Location = 73.8567, 18.5204
        }
        {
            Name = "Fuyang"
            Country = "China"
            Population = 7.6<milion>
            Location = 115.8142, 32.8907
        }
        {
            Name = "Ahmedabad"
            Country = "India"
            Population = 7.2<milion>
            Location = 72.5714, 23.0225
        }
        {
            Name = "Johannesburg"
            Country = "South Africa"
            Population = 5.6<milion>
            Location = 28.0473, -26.2041
        }
        {
            Name = "Bogota"
            Country = "Colombia"
            Population = 10.7<milion>
            Location = -74.0721, 4.7109
        }
        {
            Name = "Dar es Salaam"
            Country = "Tanzania"
            Population = 6.0<milion>
            Location = 39.2083, -6.7924
        }
        {
            Name = "Shenyang"
            Country = "China"
            Population = 8.3<milion>
            Location = 123.4315, 41.8057
        }
        {
            Name = "Khartoum"
            Country = "Sudan"
            Population = 5.2<milion>
            Location = 32.5599, 15.5007
        }
        {
            Name = "Shangqiu"
            Country = "China"
            Population = 7.4<milion>
            Location = 115.6505, 34.4371
        }
        {
            Name = "Cangzhou"
            Country = "China"
            Population = 7.7<milion>
            Location = 116.8575, 38.3106
        }
        {
            Name = "Hong Kong"
            Country = "China"
            Population = 7.5<milion>
            Location = 114.1694, 22.3193
        }
        {
            Name = "Shaoyang"
            Country = "China"
            Population = 7.0<milion>
            Location = 111.4678, 27.2389
        }
        {
            Name = "Zhanjiang"
            Country = "China"
            Population = 7.1<milion>
            Location = 110.3594, 21.2707
        }
        {
            Name = "Yancheng"
            Country = "China"
            Population = 7.3<milion>
            Location = 120.1396, 33.3776
        }
        {
            Name = "Hengyang"
            Country = "China"
            Population = 7.5<milion>
            Location = 112.5734, 26.8982
        }
        {
            Name = "Riyadh"
            Country = "Saudi Arabia"
            Population = 6.9<milion>
            Location = 46.7386, 24.7743
        }

        {
            Name = "Zhumadian"
            Country = "China"
            Population = 8.0<milion>
            Location = 114.0295, 32.9773
        }
        {
            Name = "Santiago"
            Country = "Chile"
            Population = 6.7<milion>
            Location = -70.6483, -33.4569
        }
        {
            Name = "Xingtai"
            Country = "China"
            Population = 7.1<milion>
            Location = 114.5044, 37.0706
        }
        {
            Name = "Chattogram"
            Country = "Bangladesh"
            Population = 4.5<milion>
            Location = 91.7832, 22.3569
        }
        {
            Name = "Bijie"
            Country = "China"
            Population = 3.2<milion>
            Location = 105.2850, 27.3026
        }
        {
            Name = "Shangrao"
            Country = "China"
            Population = 6.7<milion>
            Location = 117.9649, 28.4576
        }
        {
            Name = "Zunyi"
            Country = "China"
            Population = 6.3<milion>
            Location = 106.9272, 27.7255
        }
        {
            Name = "Surat"
            Country = "India"
            Population = 6.8<milion>
            Location = 72.8311, 21.1702
        }
        {
            Name = "Surabaya"
            Country = "Indonesia"
            Population = 7.3<milion>
            Location = 112.7508, -7.2575
        }
        {
            Name = "Huanggang"
            Country = "China"
            Population = 6.2<milion>
            Location = 114.8724, 30.4539
        }

        {
            Name = "Maoming"
            Country = "China"
            Population = 7.8<milion>
            Location = 110.9192, 21.6629
        }
        {
            Name = "Nanchong"
            Country = "China"
            Population = 7.5<milion>
            Location = 106.1107, 30.8378
        }
        {
            Name = "Xinyang"
            Country = "China"
            Population = 6.1<milion>
            Location = 114.0656, 32.1233
        }
        {
            Name = "Madrid"
            Country = "Spain"
            Population = 6.6<milion>
            Location = -3.7038, 40.4168
        }
        {
            Name = "Baghdad"
            Country = "Iraq"
            Population = 7.8<milion>
            Location = 44.3661, 33.3152
        }
        {
            Name = "Qujing"
            Country = "China"
            Population = 5.9<milion>
            Location = 103.7981, 25.4961
        }
        {
            Name = "Jieyang"
            Country = "China"
            Population = 6.5<milion>
            Location = 116.3728, 23.5497
        }
        {
            Name = "Singapore"
            Country = "Singapore"
            Population = 5.7<milion>
            Location = 103.8198, 1.3521
        }
        {
            Name = "Prayagraj"
            Country = "India"
            Population = 1.1<milion>
            Location = 81.8463, 25.4358
        }
        {
            Name = "Liaocheng"
            Country = "China"
            Population = 6.8<milion>
            Location = 115.9854, 36.4560
        }
        {
            Name = "Dalian"
            Country = "China"
            Population = 6.9<milion>
            Location = 121.6186, 38.9140
        }
        {
            Name = "Yulin"
            Country = "China"
            Population = 6.4<milion>
            Location = 110.1470, 22.6319
        }
        {
            Name = "Changde"
            Country = "China"
            Population = 5.7<milion>
            Location = 111.6985, 29.0316
        }
        {
            Name = "Qingdao"
            Country = "China"
            Population = 9.3<milion>
            Location = 120.3826, 36.0671
        }
        {
            Name = "Douala"
            Country = "Cameroon"
            Population = 2.8<milion>
            Location = 9.7085, 4.0511
        }
        {
            Name = "Miami"
            Country = "United States"
            Population = 0.47<milion>
            Location = -80.1918, 25.7617
        }
        {
            Name = "Nangandao"
            Country = "China"
            Population = 1.2<milion>
            Location = 113.8522, 34.0353
        }
        {
            Name = "Pudong"
            Country = "China"
            Population = 5.5<milion>
            Location = 121.5440, 31.2211
        }

        {
            Name = "Xiangyang"
            Country = "China"
            Population = 5.8<milion>
            Location = 112.1226, 32.0090
        }
        {
            Name = "Dallas"
            Country = "United States"
            Population = 1.34<milion>
            Location = -96.7970, 32.7767
        }
        {
            Name = "Houston"
            Country = "United States"
            Population = 2.31<milion>
            Location = -95.3698, 29.7604
        }
        {
            Name = "Zhengzhou"
            Country = "China"
            Population = 10.1<milion>
            Location = 113.6654, 34.7570
        }
        {
            Name = "Lu'an"
            Country = "China"
            Population = 5.9<milion>
            Location = 116.5053, 31.7556
        }
        {
            Name = "Dezhou"
            Country = "China"
            Population = 5.6<milion>
            Location = 116.3074, 37.4536
        }
        {
            Name = "Jinan"
            Country = "China"
            Population = 7.1<milion>
            Location = 117.1215, 36.6512
        }
        {
            Name = "Giza"
            Country = "Egypt"
            Population = 8.8<milion>
            Location = 31.2089, 30.0131
        }
        {
            Name = "Zhaotong"
            Country = "China"
            Population = 5.7<milion>
            Location = 103.7175, 27.3382
        }

        {
            Name = "Yichun"
            Country = "China"
            Population = 5.4<milion>
            Location = 114.3970, 27.8033
        }
        {
            Name = "Nairobi"
            Country = "Kenya"
            Population = 4.7<milion>
            Location = 36.8219, -1.2921
        }
        {
            Name = "Guadalajara"
            Country = "Mexico"
            Population = 5.2<milion>
            Location = -103.3496, 20.6597
        }
        {
            Name = "Philadelphia"
            Country = "United States"
            Population = 1.58<milion>
            Location = -75.1652, 39.9526
        }
        {
            Name = "Ankara"
            Country = "Turkey"
            Population = 5.5<milion>
            Location = 32.8597, 39.9334
        }
        {
            Name = "Tai'an"
            Country = "China"
            Population = 5.6<milion>
            Location = 117.1201, 36.6512
        }
        {
            Name = "Dazhou"
            Country = "China"
            Population = 5.7<milion>
            Location = 107.4680, 31.2096
        }

        {
            Name = "Rio de Janeiro"
            Country = "Brazil"
            Population = 6.7<milion>
            Location = -43.175927357115874, -22.907397964764513
        }
        {
            Name = "Belo Horizonte"
            Country = "Brazil"
            Population = 5.1<milion>
            Location = -43.9401, -19.9167
        }
        {
            Name = "Yongzhou"
            Country = "China"
            Population = 5.3<milion>
            Location = 111.6123, 26.4203
        }
        {
            Name = "Toronto"
            Country = "Canada"
            Population = 6.2<milion>
            Location = -79.3832, 43.6532
        }
        {
            Name = "Suihua"
            Country = "China"
            Population = 5.5<milion>
            Location = 126.9891, 46.6461
        }
        {
            Name = "Saint Petersburg"
            Country = "Russia"
            Population = 5.4<milion>
            Location = 30.3351, 59.9343
        }
        {
            Name = "Qiqihar"
            Country = "China"
            Population = 5.6<milion>
            Location = 123.9182, 47.3543
        }
        {
            Name = "Suzhou"
            Country = "China"
            Population = 10.0<milion>
            Location = 120.5853, 31.2989
        }
        {
            Name = "Monterrey"
            Country = "Mexico"
            Population = 4.7<milion>
            Location = -100.3161, 25.6866
        }
        {
            Name = "Langfang"
            Country = "China"
            Population = 4.9<milion>
            Location = 116.7077, 39.5167
        }
        {
            Name = "Weinan"
            Country = "China"
            Population = 5.3<milion>
            Location = 109.5029, 34.4994
        }
        {
            Name = "Rangoon"
            Country = "Myanmar"
            Population = 7.4<milion>
            Location = 96.1561, 16.8409
        }
    ]