   M S B A M L   `   `   `  ����F  BMediaPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MediaPlayerMediaPlayer  5   	       MediaPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:MediaPlayer     5   	     � Title$  Media player��5   	   $	��520��6   $
��1148��6+    � Icon$ media_player_22350.ico��68    � 
ResizeMode$ NoResize=�6V    � WindowStartupLocation$ CenterScreen=�6l   .��5	      � -   5         �Name$ gridName��5	      $��0,0,4,0q�6   .+�5
   
   �� -   5        $��borderMediaElement��5
      $��10,10,188,86q�6+   
���   �$��1q�6U   
�������._�5      r� -   5         r�Name$ mediaElement��5       r� LoadedBehavior$ Manual=�61    r� UnloadedBehavior$
 Stop=�6I    r� Stretch$
 Fill=�6a   $��	0,0,-1,-1q�6p   6�   5      � 5   
   -   5        $ 
bottomMenu��5      $��Bottom=�6#   $��Center=�6>   	 � RowDefinitions	 5      �� 5      $
��217* �6    �� 5      $	��15* �6    .+�5      �� -   5        
 ��Name$
 durationSlider��5      $��-121,405,10,0q�6-    � Maximum$ 13Q�6o   $	��Top=�6|   $	��757��6�    � Cursor$
 Hand��6�   �� 5      -   5        $
 volumeSlider��5      $��0,0,16,5q�6+   $��Bottom=�6=   $	��100��6X   $ 1Q�6d    � Value$ 1Q�6p   $��18��6z   $��Right=�6�   $
 Hand��6�   $��1��6�   �� 5      -   5         ��Name$ 
playButton��5      $��298,0,461,5q�6)   $��35��6>   $��30��6I   $��Bottom=�6U      ButtonPlayerControl#��[  6�   $��Center=�6�   $��2��6�   .��5      �� $7��1pack://siteoforigin:,,,/Resources/play-button.png��6   $��Center=�6S   $��Center=�6p   6�   5      �� 5      -   5        $ 
stopButton��5      $��258,0,501,5q�6)   $��Bottom=�6>   $��35��6Y   $��26��6d   #��[  6�   $��Center=�6�   $��2��6�   .��5      �� $0��*pack://siteoforigin:,,,/Resources/stop.png��6   $��Center=�6L   $��Center=�6i   6�   5      �� 5      -	   5        $ pauseButton��5      $��338,0,421,5q�6*   $��Bottom=�6?   $��35��6Z   $��26��6e   #��[  6�   $��Center=�6�   $��2��6  ��6�   Z� ��6�   Z� ��6�   Z� .��5      �� $��	pause.png��6   $��Center=�6+   $��Center=�6F   5      �� 5      -
   5        $
��Left=�5      $��-117,434,0,0q�60   $	��Top=�6F   $��40��6^   $��30��6i   #��[  6�   $��2��6�   .��5      �� $1��+pack://siteoforigin:,,,/Resources/video.png��6   $��5,1,5,-1q�6M   $��Center=�6_   $��Center=�6|   5       �� 5!      -   5         ��Name$
 info��5!      $��Label��6"   $��-112,415,139,0q�62   $	��Top=�6J   
���   �$��2��6u   �� 5"      -   5        $ 
backButton��5"      $��218,0,541,5q�6)   $��Bottom=�6>   $��35��6Y   $��26��6d   #��[  6q   $��Center=�6�   $��2��6�   .��5#      �� $��fast-back.png��6   $��Center=�6/   $��Center=�6L   6i   5$      �� 5%      -   5        $ forwardButton��5%      $��378,0,380,5q�6,   $��Bottom=�6A   $��36��6\   $��26��6g   #��[  6t   $��Center=�6�   $��2��6�   .��5&      �� $��fast-forward.png��6   $��Center=�62   6Q   5'      �� 5(      -   5        $ 
muteButton��5(      $
��Left=�6)   $��627,434,0,0q�6D   $	��Top=�6Y   $��36��6q   $��26��6|   #��[  6�   $��2��6�   .��5)      �� -   5        $��imageVolume��5)      $#��speaker-filled-audio-tool.png��6+   6T   5*      5+      �� 5,   
   -   5         ��Name$ showPlaylist��5,      $��Right=�6)   $	��389��6E   $��0,10,0,0q�6R   $	��Top=�6d   $	��173��6|    �� View 5-      �� 5.      .P�5/      �� $��	File name��6%    �� HeaderStringFormat$ 	File name��68    �� Width$	 168��6W   50      52      �� 53   
   -   5        $ playlistButton��53      $��	0,410,4,0q�6)   $	��Top=�6S   $��22��6k   $��Right=�6w   .��54      ��  �� Orientation$ 
Horizontal=�6   .+�55      �� $��playlist.png��6   $
��Fill=�6.   $��Center=�6=   $��Center=�6Z   �� 56      $��5,0,0,0q�6   �� 6.   $�Playlist��62   6E   57      58      �� 59   
   -   5        $ shuffleButton��59      $��956,410,104,0q�6(   $	��Top=�6?   $��22��6n   $��Right=�6z   .��5:      �� $ 
Horizontal=�6   .+�5;      �� $��shuffle.png��6   $
��Fill=�6-   $��Center=�6<   $��Center=�6Y   �� 5<      $��5,0,0,0q�6   �� 6.   $�Shuffle��62   6D   5=      5>      5@      5A      