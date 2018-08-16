clc;    % Clear the command window.
close all;  % Close all figures (except those of imtool.)
clear;  % Erase all existing variables. Or clearvars if you want.
workspace;  % Make sure the workspace panel is showing.
format long g;
format compact;
fontSize = 20;

rgbImage = imread('Test.bmp');
subplot(2, 3, 1);
imshow(rgbImage);
title('Original Color Image', 'FontSize', fontSize, 'Interpreter', 'None');
% Enlarge figure to full screen.
set(gcf, 'Units', 'Normalized', 'OuterPosition', [0 0 1 1]);
% Give a name to the title bar.
set(gcf, 'Name', 'Demo by ImageAnalyst', 'NumberTitle', 'Off') 

rotI = imrotate(rgbImage,33,'crop');
bw_I = rgb2gray(rgbImage);
BW = edge(bw_I,'canny');
subplot(2, 3, 2);
imshow(BW);
title('Canny Edge Image #1', 'FontSize', fontSize, 'Interpreter', 'None');

BW=edge(BW,'canny',(graythresh(rgbImage)*(0.3)),'horizontal');

subplot(2, 3, 3);
imshow(BW);
title('Canny Edge Image #1', 'FontSize', fontSize, 'Interpreter', 'None');

[H,T,R] = hough(BW);
subplot(2, 3, 4);
imshow(H,[],'XData',T,'YData',R,'InitialMagnification','fit');
title('Hough Transform', 'FontSize', fontSize, 'Interpreter', 'None');
xlabel('\theta'),
ylabel('\rho');
axis on, axis normal, hold on;
P = houghpeaks(H,15,'threshold',ceil(0.3*max(H(:))));
x = T(P(:,2));
y = R(P(:,1));
plot(x,y,'s','color','white'); % Find lines and plot them
lines = houghlines(BW,T,R,P,'FillGap',200,'MinLength',200); 
subplot(2, 3, 5);
imshow(rgbImage)
title('Image with lines', 'FontSize', fontSize, 'Interpreter', 'None');
hold on
[rows, columns] = size(BW);

for k = 1:length(lines)
	xy = [lines(k).point1; lines(k).point2];
	% Get the equation of the line
	x1 = xy(1,1);
	y1 = xy(1,2);
	x2 = xy(2,1);
	y2 = xy(2,2);
	slope = (y2-y1)/(x2-x1);
	xLeft = 1; % x is on the left edge
	yLeft = slope * (xLeft - x1) + y1;
	xRight = columns; % x is on the reight edge.
	yRight = slope * (xRight - x1) + y1;
	plot([xLeft, xRight], [yLeft, yRight], 'LineWidth',2,'Color','green');	
	
	% Plot original points on the lines .
	plot(xy(1,1),xy(1,2),'x','LineWidth',2,'Color','yellow'); 
	plot(xy(2,1),xy(2,2),'x','LineWidth',2,'Color','red');	
end
